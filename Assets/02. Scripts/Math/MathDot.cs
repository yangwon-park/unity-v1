using UnityEngine;

namespace _02._Scripts.Math
{
    public class MathDot : MonoBehaviour
    {
        public Vector3 vecA = new Vector3(1, 0, 0);
        public Vector3 vecB = new Vector3(0, 1, 0);
        
        void Start()
        {
            var result = Vector3.Dot(vecA, vecB); // 내적
            
            Debug.Log(result); // Cos(Theta)로 나옴 -> 90이면 0 (2분의 파이)
            
            var angleResult = Vector3.Angle(vecB, vecA); // 끼인각
            
            Debug.Log(angleResult);
        }
    }
}