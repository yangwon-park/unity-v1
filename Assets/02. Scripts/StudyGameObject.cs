using UnityEngine;

namespace _02._Scripts
{
    public class StudyGameObject : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        void Start()
        {
            CreateAmongus();
        }
        
        private void CreateAmongus()
        {
            GameObject obj = Instantiate(prefab);
            obj.name = "어몽어스 캐릭터";

            var objTransform = obj.transform;
            var objChildCount = objTransform.childCount;
            
            Debug.Log($"Child Object Count :: {objChildCount}");
            Debug.Log($"First Child Object Name :: {objTransform.GetChild(0).name}");
            Debug.Log($"Last Child Object Name :: {objTransform.GetChild(objChildCount-1).name}");
        }
    }
}