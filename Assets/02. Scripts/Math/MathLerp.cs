using UnityEngine;

namespace _02._Scripts.Math
{
    public class MathLerp : MonoBehaviour
    {
        public Vector3 targetPosition;
        public float lerpTime;
        
        private Vector3 _startPosition;
        private float _timer, _percent;
        
        void Start()
        {
            _startPosition = transform.position; // 시작 지점 지정
        }
        
        void Update()
        {
            // 선형 이동 (부드럽게 이동하는 경우 대부분 Lerp 사용)
            // transform.position을 기준으로 로직을 돌리면
            // 현재 위치가 매번 변하므로 목적지에 가까워질수록 점점 느려짐
            // 따라서 별도의 변수들을 받아서 일정한 속도로 시간 내에 이동하게 만들 수 있음
            
            _timer += Time.deltaTime; // 시간 조각 (프레임당 시간??)
            _percent = _timer / lerpTime;
            
            transform.position = Vector3.Lerp(_startPosition, targetPosition, _percent);
        }
    }
}