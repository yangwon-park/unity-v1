using UnityEngine;

namespace _02._Scripts.Cat
{
    public class CatController : MonoBehaviour
    {
        [SerializeField] private SoundManager soundManager; // public으로 설정했기 때문에 유니티 상에서 할당 예정
    
        private Rigidbody2D catRb;
        private Animator catAnim;
    
        [SerializeField] private float jumpPower = 30f;
        [SerializeField] private float limitPower = 25f;
        [SerializeField] private bool isGround = false;
        [SerializeField] private int jumpCount = 0;

        void Start()
        {
            catRb = GetComponent<Rigidbody2D>();
            catAnim = GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 5)
            {
                catAnim.SetTrigger("Jump");
                catAnim.SetBool("isGround", false);
                jumpCount++; // 1씩 증가
                soundManager.OnJumpSound();
                catRb.AddForceY(jumpPower, ForceMode2D.Impulse);

                if (catRb.linearVelocityY > limitPower) // 자연스러운 점프를 위한 속도 제한
                    catRb.linearVelocityY = limitPower;
            }

            var catRotation = transform.eulerAngles;
            catRotation.z = catRb.linearVelocityY * 2.5f;
            transform.eulerAngles = catRotation;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Apple"))
            {
                other.gameObject.SetActive(false);
                
                // 부모 -> Particle Object 접근 -> 활성화
                other.transform.parent.GetComponent<ItemEvent>().particle.SetActive(true);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                catAnim.SetBool("isGround", true);
                jumpCount = 0;
                isGround = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                isGround = false;
            }
        }
    }
}