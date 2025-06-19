using UnityEngine;

namespace _02._Scripts.Math
{
    public class SineLaw : MonoBehaviour
    {
        public float aAngle = 30f;
        public float bAngle = 30f;
        public float aSide = 1f;
        
        void Start()
        {
            var aRad = aAngle * Mathf.Deg2Rad;
            var bRad = bAngle * Mathf.Deg2Rad;

            var bSide = (aSide * Mathf.Sin(bRad)) / (Mathf.Sin(aRad));
            
            Debug.Log($"bSide: {bSide}");
        }
    }
}