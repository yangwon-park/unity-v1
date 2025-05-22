using UnityEngine;
using UnityEngine.UIElements;

namespace _02._Scripts
{
    public class StudyComponent : MonoBehaviour
    {
        private GameObject _obj; // Unity Editor > Inspector에서 Cube 주입받음
        [SerializeField] private string changeName;
        
        private void Start()
        {
            // _obj = GameObject.Find("Main Camera"); // Hierarchy 전체 기준으로 검색
            _obj = GameObject.FindGameObjectWithTag("Player");
            _obj.name = changeName;
            
            Debug.Log(_obj.name);
            Debug.Log(_obj.tag);
            Debug.Log(_obj.transform.position);
            Debug.Log(_obj.transform.rotation);
            Debug.Log(_obj.transform.localScale);

            Debug.Log(_obj.GetComponent<MeshFilter>().mesh);
            Debug.Log(_obj.GetComponent<MeshRenderer>().material);
        }
    }
}