using System;
using System.Collections;
using UnityEngine;

namespace _02._Scripts.Knight
{
    public class PortalController : MonoBehaviour
    {
        [SerializeField] private FadeRoutine fadeRoutine;
        [SerializeField] private GameObject portalEffect;
        [SerializeField] private GameObject loadingImage;
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
            
            // Loading
            loadingImage.SetActive(true);
            yield return fadeRoutine.Fade(3f, Color.white, false); 
            
            // Change Scene
            
            // Fade Off
        }
    }
}