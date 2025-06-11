using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace _02._Scripts.Video
{
    public class RemoteController : MonoBehaviour
    {
        [SerializeField] private GameObject videoScreen;
        [SerializeField] private Button[] buttonUIs;
        [SerializeField] private VideoClip[] videoClips;

        private bool _isMute;
        private VideoPlayer _videoPlayer;
        private int _currentClipIndex = 0;

        private void Awake()
        {
            _videoPlayer = videoScreen.GetComponent<VideoPlayer>();
            _videoPlayer.clip = videoClips[0];
        }

        private void Start()
        {
            buttonUIs[0].onClick.AddListener(OnPower);
            buttonUIs[1].onClick.AddListener(OnMute);
            buttonUIs[2].onClick.AddListener(() => OnChangeChannel(true));
            buttonUIs[3].onClick.AddListener(() => OnChangeChannel(false));
        }

        private void OnPower()
        {
            videoScreen.SetActive(!videoScreen.activeSelf);
        }

        private void OnMute()
        {
            var currentMuteStatus = !_videoPlayer.GetDirectAudioMute(0);
            _videoPlayer.SetDirectAudioMute(0, currentMuteStatus);

            // _isMute = !_isMute;
            // _videoPlayer.SetDirectAudioMute(0, _isMute);
        }

        private void OnChangeChannel(bool isNext)
        {
            if (isNext)
            {
                ChangeChannel(1);
            }
            else
            {
                ChangeChannel(-1);
            }
        }

        private void ChangeChannel(int direction)
        {
            _currentClipIndex = (_currentClipIndex + direction + videoClips.Length) % videoClips.Length;
            _videoPlayer.clip = videoClips[_currentClipIndex];
            _videoPlayer.Play();
        }
    }
}