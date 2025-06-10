using TMPro;
using UnityEngine;

namespace _02._Scripts.Cat
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playTimeUI;
        private float _timer;
        
        void Update()
        {   
            _timer += Time.deltaTime;

            playTimeUI.text = $"{_timer:F1}S";
        }
    }
}