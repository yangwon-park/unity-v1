using UnityEngine;

namespace _02._Scripts.Cat
{
    public class NameTag : MonoBehaviour
    {
        [SerializeField] private Transform cat;
        [SerializeField] private Vector3 offset; // pivot을 맞추기 위한 값
        
        void Update()
        {
            transform.position = cat.transform.position + offset;
        }
    }
}
