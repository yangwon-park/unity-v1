using UnityEngine;

namespace _02._Scripts.Monster
{
    public class Goblin : Monster
    {
        public override void Init()
        {
            hp = 3f;
            moveSpeed = 3f;
        }
    }
}