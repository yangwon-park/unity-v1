using UnityEngine;

namespace _02._Scripts.Study
{
    public class StudyFor : MonoBehaviour
    {
        public string[] persons = 
        {
            "철수",   
            "영희",
            "동수",   
            "마이클",   
            "존"   
        };
        
        private void Start()
        {
            for (var i = 0; i < 10; i++)
            {
                Debug.Log(i);
            }

            foreach (var person in persons)
            {
                Debug.Log(person);
            }
        }
    }
}