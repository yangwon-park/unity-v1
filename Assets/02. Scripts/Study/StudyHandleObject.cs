using UnityEngine;

namespace _02._Scripts.Study
{
    public class StudyHandleObject : MonoBehaviour
    {
        private int _number1;
        private int _number2;
        
        private GameObject _gameObject;
        [SerializeField] private Mesh mesh;
        [SerializeField] private Material material;

        void Start()
        {
            _gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            
            CreateCube("Generated Cube");
        }
        
        // Primitive Object는 기본적으로 생성 메소드가 제공됨
        private void CreateCube(string name)
        {
            _gameObject = new GameObject(name);

            _gameObject.AddComponent<MeshFilter>().mesh = mesh;
            _gameObject.AddComponent<MeshRenderer>().material = material;
            _gameObject.AddComponent<BoxCollider>();
        }
    }
}