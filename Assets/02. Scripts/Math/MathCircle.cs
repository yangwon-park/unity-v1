using UnityEngine;

namespace _02._Scripts.Math
{
    public class MathCircle : MonoBehaviour
    {
        private float _theta;
        [SerializeField] private float speed;
        [SerializeField] private float radius;

        void Update()
        {
            _theta += Time.deltaTime * speed;

            var pos = new Vector2(Mathf.Cos(_theta), Mathf.Sin(_theta)) * radius;
            transform.position = pos;
        }
    }
}