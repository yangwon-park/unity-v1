using UnityEngine;

namespace _02._Scripts.Roulette
{
    public class RouletteController : MonoBehaviour
    {
        [SerializeField] private float speed = -5f;
        void Update()
        {
            transform.Rotate(Vector3.forward * speed); // z축 기준으로 회전 (파랑)
        }
    }
}
