using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace _02._Scripts.Video
{
    public class RemoteController : MonoBehaviour
    {
        [SerializeField] private GameObject videoScreen;
        [SerializeField] private Button[] buttonUIs;

        private bool _isMute;
        private VideoPlayer _videoPlayer;
        
        private void Awake()
        {
            _videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        }
        
        private void Start()
        {
            buttonUIs[0].onClick.AddListener(OnPower);
            buttonUIs[1].onClick.AddListener(Mute);
            buttonUIs[2].onClick.AddListener(Prev);
            buttonUIs[3].onClick.AddListener(Next);
        }
        
        private void OnPower()
        {
            videoScreen.SetActive(!videoScreen.activeSelf);
        }
        
        private void Mute()
        {
            _isMute = !_isMute;
            _videoPlayer.SetDirectAudioMute(0, !_videoPlayer.GetDirectAudioMute(0));
            // _videoPlayer.SetDirectAudioMute(0, _videoPlayer.GetDirectAudioMute(0));
        }
        
        private void Prev()
        {
            
        }
        
        private void Next()
        {
            
        }
    }
}