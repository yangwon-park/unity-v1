using UnityEngine;

namespace _02._Scripts.Math
{
    public class MathCross : MonoBehaviour
    {
        public Vector3 vecA = new Vector3(1, 0, 0);
        public Vector3 vecB = new Vector3(0, 1, 0);
        
        void Start()
        {
            // 외적
            // 빛 관련 영역에서 많이 씀
            var crossResult = Vector3.Cross(vecA, vecB);
            Debug.Log(crossResult);
            
            var reflectResult = Vector3.Reflect(vecA, vecB);
            Debug.Log(reflectResult);
        }
    }
}