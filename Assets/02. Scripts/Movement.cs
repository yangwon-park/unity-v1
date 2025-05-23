using UnityEngine;

namespace _02._Scripts
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Update()
        {
            var h = Input.GetAxis("Horizontal"); // Legacy InputSystem -> Input Manager
            var v = Input.GetAxis("Vertical"); // -1 ~ 1

            var dir = new Vector3(h, 0, v).normalized;
            
            transform.position += dir * (speed * Time.deltaTime);
            
            transform.LookAt(transform.position + dir);
        }
    }
}