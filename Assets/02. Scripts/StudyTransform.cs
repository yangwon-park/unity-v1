using UnityEngine;

namespace _02._Scripts
{
    public class StudyTransform : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float rotateSpeed = 70f;
        
        void Update()
        {
            transform.position += Vector3.forward * (moveSpeed * Time.deltaTime);
        }
    }
}
