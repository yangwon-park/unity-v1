using UnityEngine;
using UnityEngine.UI;

namespace _02._Scripts.Knight
{
    public class KnightJoystickController : MonoBehaviour
    {
        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private Vector3 _inputDir;

        private float _speed = 3f;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            // 일정한 횟수로 실행 됨 -> 물리적인 연산을 하는데 주로 쓰임 (RigidBody 사용 시)
            HandleMovement();
        }

        public void HandleInput(float x, float y)
        {
            _inputDir = new Vector3(x, y, 0).normalized;

            _animator.SetFloat("JoystickX", x);
            _animator.SetFloat("JoystickY", y);

            if (_inputDir.x != 0)
            {
                var scaleX = _inputDir.x > 0 ? 1 : -1;
                transform.localScale = new Vector3(scaleX, 1f, 1f);
            }
        }

        private void HandleMovement()
        {
            if (_inputDir.x != 0)
            {
                _rigidbody.linearVelocity = _inputDir * _speed;
                // _rigidbody.linearVelocityX = _inputDir.x * _speed;
            }
            else
            {
                _rigidbody.linearVelocityX = 0;
            }
        }
    }
}