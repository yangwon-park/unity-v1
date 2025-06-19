using UnityEngine;

namespace _02._Scripts.Math
{
    public class MathLight : MonoBehaviour
    {
        private Light _light;
        private float _theta;
        [SerializeField] private float power;
        [SerializeField] private float speed;
        
        void Start()
        {
            _light = GetComponent<Light>();
        }
        
        void Update()
        {
            _theta += Time.deltaTime * speed;
            
            // _light.intensity = Mathf.Sin(_theta) * power
            _light.intensity = Mathf.PerlinNoise(_theta, 0) * power; // 펠린노이즈 활용
        }
    }
}