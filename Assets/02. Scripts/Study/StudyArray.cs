using UnityEngine;

namespace _02._Scripts.Study
{
    public class StudyArray : MonoBehaviour
    {
        public int[] arrayNumber = { 1, 2, 3, 4, 5 };

        void Start()
        {
            Debug.Log($"Array First Item {arrayNumber[0]}");
        }
    }
}