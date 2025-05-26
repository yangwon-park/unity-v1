using UnityEngine;

namespace _02._Scripts.Study
{
    public class StudyOperator : MonoBehaviour
    {
        [SerializeField] private int currentLevel = 10;
        [SerializeField] private int maxLevel = 99;
        void Start()
        {
            var isMax = currentLevel >= maxLevel;

            Debug.Log(isMax ? "현재 레벨은 만렙입니다." : "현재 레벨은 만렙이 아닙니다.");
        }
    }
}
