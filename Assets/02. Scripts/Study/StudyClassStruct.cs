using UnityEngine;

namespace _02._Scripts
{
    public class StudyClass
    {
        public int Number { get; set; }

        public StudyClass(int number)
        {
            Number = number;
        }
    }

    public struct StudyStruct
    {
        public int Number { get; set; }

        public StudyStruct(int number)
        {
            Number = number;
        }
    }
    
    public class StudyClassStruct : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("클래스 ------------------------------------");
            var c1 = new StudyClass(10);
            var c2 = c1;
            Debug.Log($"c1 : {c1.Number} / c2 : {c2.Number}");

            c1.Number = 100;
            Debug.Log($"c1 : {c1.Number} / c2 : {c2.Number}");

            Debug.Log("구조체 ------------------------------------");
            var s1 = new StudyStruct(10);
            var s2 = s1;
            Debug.Log($"s1 : {s1.Number} / s2 : {s2.Number}");

            s1.Number = 100;
            Debug.Log($"s1 : {s1.Number} / s2 : {s2.Number}");
        }
    }
}