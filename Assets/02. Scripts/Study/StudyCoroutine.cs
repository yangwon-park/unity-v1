using System.Collections;
using UnityEngine;

namespace _02._Scripts.Study
{
    public class StudyCoroutine : MonoBehaviour
    {
        private bool _isStop = false;
        
        private void Start()
        {
            StartCoroutine(BombRoutine());
        }
        
        IEnumerator BombRoutine()
        {
            var timer = 5;

            while (timer > 0)
            {
                Debug.Log($"{timer}초 남았습니다.");
                yield return new WaitForSeconds(1f);
                
                timer--;

                if (_isStop)
                {
                    Debug.Log("폭탄이 해제되었습니다.");
                    yield break;
                }
            }
            
            Debug.Log("폭탄이 터졌습니다.");
        }
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isStop = true;
            }
        }
    }
}
