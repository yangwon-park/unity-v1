using UnityEngine;

namespace _02._Scripts
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Update()
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            
            var dir = new Vector3(h, 0, v);
            
            Debug.Log($"현재 입력 :: {dir}");
            
            transform.position += dir * (speed * Time.deltaTime);
        }
    }
}