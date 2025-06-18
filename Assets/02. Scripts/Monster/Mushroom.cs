using UnityEngine;

namespace _02._Scripts.Monster
{
    public class Mushroom : Monster
    {
        public override void Init()
        {
            hp = 2f;
            moveSpeed = 5f;
        }
    }
}