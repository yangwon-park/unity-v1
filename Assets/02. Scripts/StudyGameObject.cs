using UnityEngine;

namespace _02._Scripts
{
    public class StudyGameObject : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject destroyObject;
        
        [SerializeField] private Vector3 pos;
        [SerializeField] private Quaternion rot;

        void Start()
        {
            Debug.Log("--- Call Start ---");
            CreateAmongus();
         
            Destroy(destroyObject, 3f);
        }
        
        void OnDestroy()
        {
            Debug.Log("--- Call OnDestroy ---");
        }
        
        private void CreateAmongus()
        {
            GameObject obj = Instantiate(prefab, pos, rot); // Gameobject 셍성 메소드 -> 위치, 회전값도 줄 수 있음
            obj.name = "어몽어스 캐릭터";
        }
    }
}