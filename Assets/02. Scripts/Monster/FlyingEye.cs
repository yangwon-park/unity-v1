using UnityEngine;

namespace _02._Scripts.Monster
{
    public class FlyingEye : Monster
    {
        public override void Init()
        {
            hp = 1f;
            moveSpeed = 2f;
        }
    }
}