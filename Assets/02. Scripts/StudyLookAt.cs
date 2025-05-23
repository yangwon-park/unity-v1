using UnityEngine;

namespace _02._Scripts
{
    public class StudyLookAt : MonoBehaviour
    {
        [SerializeField] private Transform targetTf;
        [SerializeField] private Transform turretHead;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform firePos;
        
        
        void Start()
        {
            targetTf = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void Update()
        {
            turretHead.LookAt(targetTf);
            
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
    }
}
