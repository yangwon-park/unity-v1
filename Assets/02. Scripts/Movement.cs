using UnityEngine;

namespace _02._Scripts
{
    public class Movement : MonoBehaviour
    {
        public float speed; // public -> Unity Editor에서 보임, default: private

        void Start()
        {
            
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.forward * (speed * Time.deltaTime);
            }
            
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.back * (speed * Time.deltaTime);
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * (speed * Time.deltaTime);
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * (speed * Time.deltaTime);
            }
        }
    }
}