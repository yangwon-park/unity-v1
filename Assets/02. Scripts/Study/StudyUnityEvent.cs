using System;
using UnityEngine;

namespace _02._Scripts.Study
{
    public class StudyUnityEvent : MonoBehaviour
    {
        void Awake() // 가장 먼저 1회 실행
        {
            Debug.Log("Awake");
        }

        void OnEnable() // 켜졌을 때 1회 실행
        {
            Debug.Log("OnEnable");
        }

        private void OnDisable()
        {
            Debug.Log("OnDisable");
        }

        void Start() // Awake 이후 1회 실행
        {
            Debug.Log("Start");
        }

        void Update()
        {
        
        }
    }
}
