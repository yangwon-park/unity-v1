using UnityEngine;

namespace _02._Scripts.Roulette
{
    public class RouletteController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private bool isStop;
        void Start()
        {
            speed = 0f;
        }
        
        void Update()
        {
            transform.Rotate(Vector3.forward * speed); // z축 기준으로 회전 (파랑)
            
            // 마우스 좌클릭 시, 회전 시작
            if (Input.GetMouseButtonDown(0))
            {
                speed = -5f;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                isStop = true;
            }

            if (isStop)
            {
                speed *= 0.98f;
                
                if (speed > -0.01f)
                {
                    speed = 0f;
                    isStop = false;
                }
            }
        }
    }
}