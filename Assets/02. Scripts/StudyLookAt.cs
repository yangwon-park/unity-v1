using UnityEngine;

namespace _02._Scripts
{
    public class StudyLookAt : MonoBehaviour
    {
        [SerializeField] private Transform targetTf;
        [SerializeField] private Transform turretHead;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform firePos;

        [SerializeField] private float timer; // frame 조각 간의 시간 차이
        [SerializeField] private float cooldownTime;
        
        
        void Start()
        {
            targetTf = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void Update()
        {
            turretHead.LookAt(targetTf);

            timer += Time.deltaTime;

            if (!(timer >= cooldownTime)) return;
            
            timer = 0f;
            
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
    }
}
