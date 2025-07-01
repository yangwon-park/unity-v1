using System;
using UnityEngine;
using UnityEngine.UI;

namespace _02._Scripts.Knight
{
    public class KnightSoundManager : MonoBehaviour
    {
        // Sound 재생 방식
        // Play() -> 계속 나오는 경우 (BGM, 앰비언트)
        // PlayOneShout() -> 효과음
        
        [SerializeField] private AudioSource bgmAudioSource;
        [SerializeField] private AudioSource eventAudioSource;
        [SerializeField] private AudioClip[] clips;
        [SerializeField] private Slider bgmVolume;
        [SerializeField] private Slider eventVolume;
        [SerializeField] private Toggle bgmMute;
        [SerializeField] private Toggle eventMute;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject); // 다른 씬에서도 그대로 사용
            
            bgmVolume.value = bgmAudioSource.volume;
            eventVolume.value = eventAudioSource.volume;
            
            bgmMute.isOn = bgmAudioSource.mute;
            eventMute.isOn = bgmAudioSource.mute;
        }

        private void Start()
        {
            BgmPlay("Town BGM");

            bgmVolume.onValueChanged.AddListener(OnBgmVolumeChange);
            eventVolume.onValueChanged.AddListener(OnEventVolumeChange);
            
            bgmMute.onValueChanged.AddListener(OnBgmMute);
            eventMute.onValueChanged.AddListener(OnEventMute);
        }
        
        private void OnDestroy()
        {
            // 메모리 누수 방지
            bgmVolume.onValueChanged.RemoveListener(OnBgmVolumeChange);
            eventVolume.onValueChanged.RemoveListener(OnEventVolumeChange);
            
            bgmMute.onValueChanged.RemoveListener(OnBgmMute);
            eventMute.onValueChanged.RemoveListener(OnEventMute);
        }

        public void EventSoundPlay(string clipName)
        {
            foreach (var clip in clips)
            {
                if (clip.name != clipName) continue;
                eventAudioSource.PlayOneShot(clip);

                return;
            }
         
            Debug.LogError($"{clipName}을 찾지 못하였습니다.");
        }

        private void BgmPlay(string clipName)
        {
            foreach (var clip in clips)
            {
                if (clip.name != clipName) continue;
                bgmAudioSource.clip = clip;
                bgmAudioSource.Play();

                return;
            }
            
            Debug.LogError($"{clipName}을 찾지 못하였습니다.");
        }

        private void OnBgmVolumeChange(float value)
        {
            bgmAudioSource.volume = value;
        }
        
        private void OnEventVolumeChange(float value)
        {
            eventAudioSource.volume = value;
        }

        private void OnBgmMute(bool isMuted)
        {
            bgmAudioSource.mute = isMuted;
        }
        
        private void OnEventMute(bool isMuted)
        {
            eventAudioSource.mute = isMuted;
        }
    }
}