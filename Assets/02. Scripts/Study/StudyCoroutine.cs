using System.Collections;
using UnityEngine;

namespace _02._Scripts.Study
{
    public class StudyCoroutine : MonoBehaviour
    {
        private Coroutine _routine;
     
        // 아래와 같이 Start Method 자체를 Coroutine으로 동작하게 할 수 있음
        // IEnumerator Start()
        // {
        //     while (true) // Coroutine 내부에서 무한 루프를 돌려도 1f 동안 Wait가 있기 떄문에 부하가 크지 않음 => Update 대용으로 사용
        //     {
        //          yield return WaitForSeconds(1f);
        //     }
        // }
        
        void Start()
        {
            // 호출 방식
            StartCoroutine(nameof(RoutineA));
            StartCoroutine(RoutineA());
            _routine = StartCoroutine(RoutineA());
            
            // Stop 방식
            StopCoroutine(RoutineA());          // 동작 X
            StopCoroutine(_routine);            // 동작 O
            StopCoroutine(nameof(RoutineA));    // 동작 O
            StopAllCoroutines();                // 동작 O
        }

        // 반드시 yield 문을 활용하여 return 해주어야 함
        // Coroutine은 Invoke와 다르게 Parameter를 전달할 수 있음
        private IEnumerator RoutineA() // 대기
        {
            yield return new WaitForSeconds(2f); // 3초 대기
            Debug.Log("Coroutine 1단계 실행");
            
            yield return new WaitForSeconds(2f); // 3초 대기
            Debug.Log("Coroutine 2단계 실행");
            
            yield return new WaitForSeconds(2f); // 3초 대기
            Debug.Log("Coroutine 3단계 실행");
        }
    }
}
