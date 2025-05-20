using UnityEngine;

namespace _02._Scripts
{
    public class StudyLog : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Debug.Log("[ Call Start Method ]");
            Debug.LogWarning("[ Call Start Method ]");
            Debug.LogError("[ Call Start Method ]");
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}