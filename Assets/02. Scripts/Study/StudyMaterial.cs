using UnityEngine;

namespace _02._Scripts.Study
{
    public class StudyMaterial : MonoBehaviour
    {
        [SerializeField] private Material material;
        [SerializeField] private string hexCode;

        void Start()
        {
            // MeshRenderer에 접근하여 바꿔야함
            // GetComponent<MeshRenderer>().sharedMaterial = material; 
            // GetComponent<MeshRenderer>().material.color = Color.green; // 인스턴스화 시켜서 값만 바뀜
            // GetComponent<MeshRenderer>().material.color = new Color(200, 137, 79, 255);
            
            // sharedMaterial.color: 동일한 Material을 공유하고 있는 모든 Object의 색을 바꿈, 종료해도 색이 그대로 변해있음 -> 원본 데이터 자체를 바꿔버림
            // GetComponent<MeshRenderer>().sharedMaterial.color = Color.green;

            material = GetComponent<MeshRenderer>().material;
            
            if (ColorUtility.TryParseHtmlString(hexCode, out var color))
            {
                material.color = color;
            }
        }
    }
}