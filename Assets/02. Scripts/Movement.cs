using UnityEngine;

namespace _02._Scripts
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Update()
        {
            // Object Top 뷰(3차원)로 보고 있을 때 기준으로 Horizontal(좌우, x축), Vertical(앞뒤, z축) 동작함
            var h = Input.GetAxis("Horizontal"); // Legacy InputSystem -> Input Manager
            var v = Input.GetAxis("Vertical");
            
            // var h = Input.GetAxisRaw("Horizontal");
            // var v = Input.GetAxisRaw("Vertical");
            //
            var dir = new Vector3(h, 0, v);
            
            // 정규화 과정 (0 ~ 1) => 반지름 1인 1/4의 호가 생김 => 정규화 하지 않으면 대각선 속도가 더 빨라짐
            var normalDir = dir.normalized;
            
            transform.position += normalDir * (speed * Time.deltaTime);
        }
    }
}