using UnityEngine;

namespace _02._Scripts.Math
{
    public class CosineLaw : MonoBehaviour
    {
        public float aSide = 1f;
        public float bSide = 1f;
        public float cAngle = 60f;

        void Start()
        {
            var cRad = cAngle * Mathf.Deg2Rad;
            var cSide = Mathf.Sqrt(Mathf.Pow(aSide, 2) + Mathf.Pow(bSide, 2) - (2 * aSide * bSide * Mathf.Cos(cRad)));
            
            Debug.Log($"cSide : {cSide}");
        }
    }
}