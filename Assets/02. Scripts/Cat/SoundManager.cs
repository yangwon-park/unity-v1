using UnityEngine;

namespace _02._Scripts.Cat
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource; // 소리 출력 역할
        [SerializeField] private AudioClip bgmClip;
        [SerializeField] private AudioClip jumpClip;
        
        private void Start()
        {
            SetBGMSound();
        }

        private void SetBGMSound()
        {
            audioSource.clip = bgmClip;
            audioSource.playOnAwake = true;
            audioSource.loop = true;
            audioSource.volume = 0.1f;
            
            audioSource.Play();
        }
        
        
        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip); // 1회 실행 -> 제어 불가
        }
    }
}
