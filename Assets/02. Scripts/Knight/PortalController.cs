using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _02._Scripts.Knight
{
    public class PortalController : MonoBehaviour
    {
        [SerializeField] private FadeRoutine fadeRoutine;
        [SerializeField] private GameObject portalEffect;
        [SerializeField] private GameObject loadingImage;
        [SerializeField] private Image progressBar;
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(PortalRoutine());
            }
        }
        
        private IEnumerator PortalRoutine()
        {
            portalEffect.SetActive(true);
            yield return fadeRoutine.Fade(3f, Color.white, true);
            
            loadingImage.SetActive(true);
            yield return fadeRoutine.Fade(3f, Color.white, false);
            
            // Loading
            while (progressBar.fillAmount < 1)
            {
                progressBar.fillAmount += Time.deltaTime * 0.3f;
                yield return null;
            }

            // Change Scene
            SceneManager.LoadScene(1);
        }
    }
}