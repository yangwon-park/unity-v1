using UnityEngine;

namespace _02._Scripts.Study
{
    public class StudyTransform : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float rotateSpeed = 70f;

        void Update()
        {
            var angle = transform.rotation.eulerAngles.y + (rotateSpeed * Time.deltaTime);
            
            // 월드 방향으로 이동, 회전
            // transform.position += Vector3.forward * (moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime), Space.World); // 이동
            // transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);

            // 로컬 방향 이동, 회전
            // localPosition, localRotation -> 계층 구조가 존재해야함, 부모가 없는 경우 World가 기준이 됨
            transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime)); // 이동
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime); // Self 생략
            
            // 특정 위치 주변 회전
            transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }
}