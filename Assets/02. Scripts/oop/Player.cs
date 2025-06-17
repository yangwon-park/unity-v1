using UnityEngine;

namespace _02._Scripts.oop
{
    public class Player : Character
    {
        public override void Attack()
        {
            Debug.Log("Player Attack");
        }
        
        public override void Move()
        {
            Debug.Log("Player Move");
        }
    }
}