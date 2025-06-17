using UnityEngine;

namespace _02._Scripts.oop
{
    public class Monster : Character
    {
        public override void Attack()
        {
            Debug.Log("Monster Attack");
        }
        
        public override void Move()
        {
            Debug.Log("Monster Move");
        }
    }
}