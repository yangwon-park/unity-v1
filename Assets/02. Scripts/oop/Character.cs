using UnityEngine;

namespace _02._Scripts.oop
{
    public class Character : MonoBehaviour
    {
        public float hp;
        public float moveSpeed;
        
        public virtual void Attack()
        {
            Debug.Log("Attack");    
        }
        
        public virtual void Move()
        {
            Debug.Log("Move");    
        }
    }
}