using UnityEngine;

namespace _02._Scripts
{
    public class StudyHandleObject : MonoBehaviour
    {
        private GameObject _gameObject;
        [SerializeField] private Mesh mesh;
        [SerializeField] private Material material;

        void Start()
        {
            _gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _gameObject.AddComponent<MeshFilter>().mesh = mesh;
            _gameObject.AddComponent<MeshRenderer>().material = material;
            _gameObject.AddComponent<BoxCollider>();
            
            // CreateCube();
        }

        // Primitive Object는 기본적으로 생성 메소드가 제공됨
        private void CreateCube()
        {
            _gameObject = new GameObject("Generated Cube");

            _gameObject.AddComponent<MeshFilter>().mesh = mesh;
            _gameObject.AddComponent<MeshRenderer>().material = material;
            _gameObject.AddComponent<BoxCollider>();
        }
    }
}