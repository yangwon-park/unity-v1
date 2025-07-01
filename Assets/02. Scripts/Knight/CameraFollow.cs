using UnityEngine;

namespace _02._Scripts.Knight
{
    public class CameraFollow : MonoBehaviour
    {
        // CineMachine 쓰기 전에 코드 상으로 직접 카메라 Follow 기능 구현
        // 캐릭터 이동 -> 카메라 이동 순
        [SerializeField] private Vector2 minBound;
        [SerializeField] private Vector2 maxBound;
        
        private Transform _target;
        private Vector3 _offset;
        private readonly float _cameraSpeed = 3f;
        private KnightKeyboardController _knightKeyboardController;

        void Start()
        {
            _target = GameObject.FindGameObjectWithTag("Player").transform;
            _offset = new Vector3(0, 3.25f, 0);
        }
        
        void LateUpdate()
        {
            var destination = _target.position + _offset;
            var smoothPosition = Vector3.Lerp(transform.position, destination, Time.deltaTime * _cameraSpeed);
            
            smoothPosition.x = Mathf.Clamp(smoothPosition.x, minBound.x, maxBound.x);
            smoothPosition.y = Mathf.Clamp(smoothPosition.y, minBound.y, maxBound.y);
            
            transform.position = smoothPosition;
        }
    }
}