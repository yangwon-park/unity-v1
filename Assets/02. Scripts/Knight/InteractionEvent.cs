using System;
using UnityEngine;

namespace _02._Scripts.Knight
{
    public class InteractionEvent : MonoBehaviour
    {
        public enum InteractionType {Sign, Door, Npc}
        public InteractionType interactionType;
        public GameObject popup;

        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.CompareTag("Player"))
            {
                Interaction(other.transform);
            }
        }

        void Interaction(Transform player)
        {
            switch (interactionType)
            {
                case InteractionType.Sign:
                    popup.SetActive(true);
                    break;
                case InteractionType.Door:
                
                    break;
                case InteractionType.Npc:
                
                    break;
            }
        }
    }
}