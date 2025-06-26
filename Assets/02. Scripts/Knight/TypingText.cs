using System.Collections;
using TMPro;
using UnityEngine;

namespace _02._Scripts.Knight
{
    public class TypingText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textUI;
        private string _currText;
        private float _typingSpeed = 0.1f;
        
        void Awake()
        {
            _currText = textUI.text;
        }
        
        void OnEnable()
        {
            textUI.text = string.Empty;

            StartCoroutine(TypingRoutine());
        }

        IEnumerator TypingRoutine()
        {
            var textCount = _currText.Length;

            for (var i = 0; i < textCount; i++)
            {
                textUI.text += _currText[i];
                yield return new WaitForSeconds(_typingSpeed);
            }
        }
    }
}