using UnityEngine;
using UnityEngine.UI;

namespace _02._Scripts.Knight
{
    public class KnightKeyboardController : MonoBehaviour, IDamageable
    {
        [SerializeField] private Image hpBar;
        
        private Animator _animator;
        private Rigidbody2D _rb;
        private Collider2D _collider;
        private Vector3 _inputDir;
        private bool _isJumpInput;
        private bool _isGround;
        private bool _isAttack;
        private bool _isCombo;
        private bool _isLadder;
        private float _akDamage = 3f;
        private float _speed = 3f;
        private float _jumpPower = 10f;
        private float _hp = 100f;
        private float _currentHp;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();

            _currentHp = _hp;
            hpBar.fillAmount = _currentHp / _hp;
        }

        private void Update()
        {
            HandleInput();
            HandleSpriteDirection();
            HandleAnimator();
            Jump();

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Attack();
            }
        }

        private void FixedUpdate()
        {
            // 일정한 횟수로 실행 됨 -> 물리적인 연산을 하는데 주로 쓰임 (RigidBody 사용 시)
            HandleMovement();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Ground")) return;
            _animator.SetBool("isGround", true);
            _isGround = true;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Ground")) return;
            _animator.SetBool("isGround", false);
            _isGround = false;
        }


        // Collider가 아예 움직임 자체가 없으면 OnOff하여도 동작되지 않음

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Monster"))
            {
                other.GetComponent<IDamageable>()?.TakeDamage(_akDamage);
                other.GetComponent<Animator>()?.SetTrigger("Hit");
            }
            else if (other.CompareTag("Ladder"))
            {
                _isLadder = true;
                _rb.gravityScale = 0;
                _rb.linearVelocity = Vector2.zero;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Ladder")) return;
            _isLadder = false;
            _rb.gravityScale = 2f;
            _rb.linearVelocity = Vector2.zero;
        }

        public void TakeDamage(float damage)
        {
            _currentHp -= damage;
            
            hpBar.fillAmount = _currentHp / _hp;
            
            Debug.Log($"현재 체력 :: {_currentHp}");
            Debug.Log($"현재 체력 퍼센트 :: {hpBar.fillAmount}");
            
            if (_currentHp <= 0f)
            {
                Death();
            }
        }

        public void Death()
        {
            _animator.SetTrigger("Death");
            _collider.enabled = false;
            _rb.gravityScale = 0;
        }

        private void HandleInput()
        {
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            _inputDir = new Vector3(h, v, 0);

            if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            {
                _isJumpInput = true;
            }
        }

        private void HandleMovement()
        {
            if (_inputDir.x != 0)
            {
                _rb.linearVelocityX = _inputDir.x * _speed;
            }
            else
            {
                _rb.linearVelocityX = 0;
            }

            if (_isLadder && _inputDir.y != 0)
            {
                _rb.linearVelocityY = _inputDir.y * _speed;
            }
        }

        private void Jump()
        {
            if (!_isJumpInput || !_isGround) return;
            _rb.AddForceY(_jumpPower, ForceMode2D.Impulse);
            _isJumpInput = false;
        }

        private void HandleSpriteDirection()
        {
            if (_inputDir.x == 0) return; // 이게 없으면 이전 방향으로 다시 바라봄 (왼쪽 보다 오른쪽 가도 다시 왼쪽으로 쳐다봄)
            var direction = _inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(direction, 1f, 1f);
        }

        private void HandleAnimator()
        {
            _animator.SetFloat("JoystickX", _inputDir.x);
            _animator.SetFloat("JoystickY", _inputDir.y);
            
            if (_isJumpInput && _isGround)
            {
                _animator.SetTrigger("Jump");
            }

            if (_inputDir.y < 0)
            {
                GetComponent<CapsuleCollider2D>().size = new Vector2(0.5f, 0.3f);
            }
            else
            {
                GetComponent<CapsuleCollider2D>().size = new Vector2(0.5f, 2f);
            }
        }

        private void Attack()
        {
            if (!_isAttack)
            {
                _isAttack = true;
                _akDamage = 3f;
                _animator.SetTrigger("Attack");
            }
            else
            {
                _isCombo = true;
            }
        }

        private void CheckCombo()
        {
            if (_isCombo)
            {
                _animator.SetBool("isCombo", true);
                _akDamage = 5f;
            }
            else
            {
                _animator.SetBool("isCombo", false);
                _isAttack = false;
            }
        }

        // 콤보가 복잡해질 경우를 대비해 EndCombo를 별도의 메소드로 처리 -> Animation Event로 동작하게 만듦
        // Animator + Script 있는 경우, Script에 있는 메소드에 접근할 수 있음
        private void EndCombo()
        {
            _isAttack = false;
            _isCombo = false;
            _animator.SetBool("isCombo", false);
        }
    }
}