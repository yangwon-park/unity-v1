using System;
using UnityEngine;

namespace _02._Scripts
{
    public class DestroyEvent : MonoBehaviour
    {
        [SerializeField] private float destroyTime;

        void Start()
        {
            Destroy(gameObject, destroyTime);
        }

        private void OnDestroy()
        {
            Debug.Log($"{gameObject}가 파괴되었습니다.");
        }
    }
}
