using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _02._Scripts.Study
{
    public class StudyFadeRoutine : MonoBehaviour
    {
        [SerializeField] private Image fadePanel;
        [SerializeField] private bool isFadeIn = false;
        
        
        private void Start()
        {
            StartCoroutine(FadeRoutineA(3));
        }
        
        private IEnumerator FadeRoutineA(float fadeTime)
        {
            var timer = 0f;
            var percentage = 0f;
            var value = isFadeIn ? percentage : 1 - percentage;
            
            while (percentage <= 1f)
            {
                timer += Time.deltaTime;
                percentage = timer / fadeTime;
                
                fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, value);
                
                yield return null;
            }
        }
    }
}