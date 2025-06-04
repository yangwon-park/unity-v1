using UnityEngine;

namespace _02._Scripts.Cat
{
    public class CatController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D catRb;
        [SerializeField] private Animator catAnimator;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private bool isGround = false;
        [SerializeField] private int jumpCount = 0;
        [SerializeField] private SoundManager soundManager;
        
        private void Start()
        {
            catRb = GetComponent<Rigidbody2D>();
            catAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            OnJump();
        }

        private void OnJump()
        {
            if (!Input.GetKeyDown(KeyCode.Space) || jumpCount >= 2) return;
            
            catAnimator.SetTrigger("Jump");
            catAnimator.SetBool("isGround", false);
            catRb.AddForceY(jumpForce, ForceMode2D.Impulse);
            jumpCount++;
            soundManager.OnJumpSound();
        }

        // CollisionEnter -> 충돌이 발생했을 떄
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Ground")) return;
            
            catAnimator.SetBool("isGround", true);
            jumpCount = 0;
            isGround = true;
        }
        
        private void OnCollisionExit2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Ground")) return;
            
            isGround = false;
        }
    }
}
