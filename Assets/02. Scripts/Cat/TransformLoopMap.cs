using UnityEngine;

namespace _02._Scripts.Cat
{
    public class TransformLoopMap : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Vector3 _returnPos;
        private float _width;

        void Start()
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            _width = spriteRenderer.bounds.size.x;
        }

        void Update()
        {
            transform.position += Vector3.left * (speed * Time.deltaTime);

            if (transform.position.x <= -_width)
            {
                // 현재 위치에서 상대적으로 이동 (연결 유지)
                transform.position += Vector3.right * (_width * 2);
            }
        }
    }
}