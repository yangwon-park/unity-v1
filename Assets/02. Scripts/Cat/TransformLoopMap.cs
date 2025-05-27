using UnityEngine;

namespace _02._Scripts.Cat
{
    public class TransformLoopMap : MonoBehaviour
    {
        public float moveSpeed = 3f;

        public Vector3 returnPos = new Vector3(30f, 1.5f, 0f);

        void Update()
        {
            transform.position += Vector3.left * (moveSpeed * Time.fixedDeltaTime);

            if (transform.position.x <= -30f) // 이미지의 x축 값이 -30을 넘는 순간
            {
                transform.position = returnPos; // 다시 사용하기 위해서 오른쪽 x = 30으로 초기화
            }
        }
    }
}