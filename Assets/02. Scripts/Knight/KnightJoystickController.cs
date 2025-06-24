using UnityEngine;
using UnityEngine.UI;

namespace _02._Scripts.Knight
{
    public class KnightJoystickController : MonoBehaviour
    {
        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private Vector3 _inputDir;
        private bool _isGround = false;
        [SerializeField] private float speed = 3f;
        [SerializeField] private float jumpPower = 10f;
        [SerializeField] private Button jumpButton;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            
            jumpButton.onClick.AddListener(HandleJump);
        }

        private void Update()
        {
            
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

        public void HandleInput(float x, float y)
        {
            _inputDir = new Vector3(x, y, 0).normalized;
            
            _animator.SetFloat("JoystickX", x);
            _animator.SetFloat("JoystickY", y);

            if (_inputDir.x != 0)
            {
                var scaleX = _inputDir.x > 0 ? 1 : -1;
                transform.localScale = new Vector3(scaleX, 1, 1);
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
            if (!_isGround) return;
            _animator.SetTrigger("Jump");
            _rigidbody.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }
}