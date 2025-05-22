using UnityEngine;
using UnityEngine.UIElements;

namespace _02._Scripts
{
    public class StudyComponent : MonoBehaviour
    {
        private GameObject _gameObject; // Unity Editor > Inspector에서 Cube 주입받음
        private Transform _transform;
        
        private void Start()
        {
            // _obj = GameObject.Find("Main Camera"); // Hierarchy 전체 기준으로 검색
            _gameObject = GameObject.FindGameObjectWithTag("Player");
            _transform = GameObject.FindGameObjectWithTag("Player").transform;
            
            _gameObject.GetComponent<MeshRenderer>().enabled = false; // 투명 벽 => Rendering만 하지 않을 뿐, 실제로 Object는 존재함
            
            _gameObject.SetActive(false);
        }
    }
}