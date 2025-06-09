using UnityEngine;

namespace _02._Scripts.Study
{
    public class StudyRandom : MonoBehaviour
    {
        void OnEnable()
        {
            var num = Random.Range(0f, 100f); // 몬스터 랜덤 생성시 활용 가능 (뱀서류)
            
            Debug.Log($"{num}");
        }
    }
}