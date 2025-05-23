using UnityEngine;

namespace _02._Scripts.Solar_System_3D
{
    public class PlanetRotation : MonoBehaviour
    {
        [SerializeField] private Transform targetPlanet;
        [SerializeField] private float rotationSpeed = 30f;
        [SerializeField] private float revolutionSpeed = 100f;
        [SerializeField] private bool isRevolution;

        void Update()
        {
            // 자전
            transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
            
            if (isRevolution)
            {
                // 공전
                transform.RotateAround(targetPlanet.position, Vector3.up, revolutionSpeed * Time.deltaTime);
            }
        }
    }
}