using UnityEngine;

namespace _02._Scripts
{
    public class StudyComponent : MonoBehaviour
    {
        private GameObject _obj; // Unity Editor > Inspector에서 Cube 주입받음
        [SerializeField] private string changeName;
        
        private void Start()
        {
            _obj = GameObject.Find("Main Camera"); // Hierarchy 전체 기준으로 검색
            
            _obj.name = changeName;
        }
    }
}