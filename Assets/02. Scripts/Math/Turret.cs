using UnityEngine;

namespace _02._Scripts.Math
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private Transform turretHead;
        [SerializeField] private Transform target;
        [SerializeField] private float rotSpeed = 1f;
        [SerializeField] private float rotRange = 60f;

        private float _theta;
        private bool _isTarget;

        void Update()
        {
            if (!_isTarget)
            {
                TurretIdleState();
            }
            else
            {
                LookAtTarget();
            }
        }
        
        void LookAtTarget()
        {
            turretHead.LookAt(target);
        }
        
        void TurretIdleState()
        {
            _theta += Time.deltaTime * rotSpeed;
                
            var rotY = Mathf.Sin(_theta) * rotRange;
                
            turretHead.localRotation = Quaternion.Euler(0, rotY, 0);
        }
        
        // Trigger 동작 시, 적어도 하나의 GameObject는 RigidBody 필수
        void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            
            target = other.transform;
            _isTarget = true;
        }

        void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            target = other.transform;
            _isTarget = false;
        }
    }
}
