using UnityEngine;

namespace _02._Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 100f;
        
        void Update()
        {
            // Vector3.forward -> Scene 기준에서의 정면 
            // transform.position += Vector3.forward * (speed * Time.deltaTime);
            
            // Local의 정면
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
    }
}
