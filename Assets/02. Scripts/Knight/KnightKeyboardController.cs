using UnityEngine;

namespace _02._Scripts.Knight
{
    public class KnightKeyboardController : MonoBehaviour
    {
        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private Vector3 _inputDir;
        private bool _isJumpInput = false;
        private bool _isGround = false;
        [SerializeField] private float speed = 3f;
        [SerializeField] private float jumpPower = 10f;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            HandleInput();
            HandleSpriteDirection();
            HandleJump();
            HandleAnimator();
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

        private void HandleInput()
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
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
                _rigidbody.linearVelocityX = _inputDir.x * speed;
            }
            else
            {
                _rigidbody.linearVelocityX = 0;
            }
        }

        private void HandleJump()
        {
            if (!_isJumpInput || !_isGround) return;
            // if (!Input.GetKeyDown(KeyCode.Space) || !_isGround) return;
            _rigidbody.AddForceY(jumpPower, ForceMode2D.Impulse);
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
            var isMoving = Mathf.Abs(_inputDir.x) > 0.1f;
            _animator.SetBool("isRun", isMoving);

            if (_isJumpInput && _isGround)
            {
                _animator.SetTrigger("Jump");
            }
        }
    }
}