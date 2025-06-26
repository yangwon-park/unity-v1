using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _02._Scripts.Knight
{
    public class FadeRoutine : MonoBehaviour
    {
        public Image panel;

        public IEnumerator Fade(float fadeTime, Color color, bool isFadeStart)
        {
            var timer = 0f;
            var percent = 0f;
            
            while (percent < 1f)
            {
                timer += Time.deltaTime;
                percent = timer / fadeTime;
                
                var value = isFadeStart ? percent : 1 - percent;
                
                panel.color = new Color(color.r, color.g, color.b, value);
                
                yield return null;
            }
        }
    }
}