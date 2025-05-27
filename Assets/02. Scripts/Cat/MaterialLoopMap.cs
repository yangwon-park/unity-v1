using UnityEngine;

namespace _02._Scripts.Cat
{
    public class MaterialLoopMap : MonoBehaviour
    {
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");
        private MeshRenderer _meshRenderer;
        [SerializeField] private float speed = 0.1f;
        
        void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        void Update()
        {
            // 변경된 offset 값
            Vector2 offSet = Vector2.right * (speed * Time.deltaTime);
            
            // Texture의 Offset을 적용
            // _MainTex-> Base Map
            _meshRenderer.material.SetTextureOffset(MainTex, _meshRenderer.material.mainTextureOffset + offSet);
        }
    }
}
