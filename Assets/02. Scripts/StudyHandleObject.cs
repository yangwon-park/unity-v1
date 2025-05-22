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
            CreateCube();
        }

        private void CreateCube()
        {
            _gameObject = new GameObject("Generated Cube");

            _gameObject.AddComponent<MeshFilter>().mesh = mesh;
            _gameObject.AddComponent<MeshRenderer>().material = material;
            _gameObject.AddComponent<BoxCollider>();
        }
    }
}