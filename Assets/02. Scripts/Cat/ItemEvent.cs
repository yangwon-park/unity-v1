using UnityEngine;

namespace _02._Scripts.Cat
{
    public class ItemEvent : MonoBehaviour
    {
        public GameObject particle;
        
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private float returnPosX = 15f;
        [SerializeField] private float randomPosY;

        void Start()
        {
            randomPosY = Random.Range(-8, -3);

            transform.position = new Vector3(transform.position.x, randomPosY, 0);
        }

        void Update()
        {
            transform.position += Vector3.left * (moveSpeed * Time.deltaTime);

            if (transform.position.x <= -returnPosX)
            {
                randomPosY = Random.Range(-8f, -3.5f);
                // randomPosY = Random.Range(-8, -3);

                transform.position = new Vector3(returnPosX, randomPosY, 0);
            }
        }
    }
}