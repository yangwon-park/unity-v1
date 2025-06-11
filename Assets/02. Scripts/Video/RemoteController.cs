using UnityEngine;
using UnityEngine.UI;

namespace _02._Scripts.Video
{
    public class RemoteController : MonoBehaviour
    {
        [SerializeField] private GameObject videoScreen;
        [SerializeField] private Button[] buttonUIs;        
        
        public void OnPower()
        {
            videoScreen.SetActive(!videoScreen.activeSelf);
            
            
        }
    }
}