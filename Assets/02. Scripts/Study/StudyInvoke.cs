using System.Threading;
using UnityEngine;

namespace _02._Scripts.Study
{
    // invoke
    // 메소드 지연 실행
    
    public class StudyInvoke : MonoBehaviour
    {
        [SerializeField] private float time;
        [SerializeField] private int count;
        
        private void Start()
        {
            InvokeRepeating(nameof(Bomb), 0f, 1f);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CancelInvoke(nameof(Bomb));
                Debug.Log("폭탄이 해제되었습니다.");
            }
        }

        private void Bomb()
        {
            Debug.Log($"현재 남은 시간 :: {count}");
            count--;

            if (count == 0)
            {
                Debug.Log($"폭탄이 터졌습니다.");
            }
        }
    }
}