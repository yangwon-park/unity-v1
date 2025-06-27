using System.Collections;
using UnityEngine;

namespace _02._Scripts.Knight
{
    public class InteractionEvent : MonoBehaviour
    {
        [SerializeField] private GameObject popup;
        [SerializeField] private GameObject map;
        [SerializeField] private GameObject house;
        [SerializeField] private FadeRoutine fade;
        [SerializeField] private Vector3 indoorPos;
        [SerializeField] private Vector3 outdoorPos;
        [SerializeField]private KnightSoundManager soundManager;

        public enum InteractionType
        {
            Sign,
            Door,
            Npc
        }

        public InteractionType interactionType;
        private bool _isHouse;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Interaction(other.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                popup.SetActive(false);
            }
        }

        void Interaction(Transform player)
        {
            switch (interactionType)
            {
                case InteractionType.Sign:
                    Debug.Log("On Sign Trigger");
                    popup.SetActive(true);
                    break;
                case InteractionType.Door:
                    StartCoroutine(DoorRoutine(player));
                    break;
                case InteractionType.Npc:
                    Debug.Log("On NPC Trigger");
                    popup.SetActive(true);
                    break;
            }
        }

        IEnumerator DoorRoutine(Transform player)
        {
            soundManager.EventSoundPlay("Door");
            
            yield return StartCoroutine(fade.Fade(3f, Color.black, true));

            map.SetActive(_isHouse);
            house.SetActive(!_isHouse);
 
            player.transform.position = !_isHouse ? indoorPos : outdoorPos;

            _isHouse = !_isHouse;
            
            yield return new WaitForSeconds(1f);
            yield return StartCoroutine(fade.Fade(3f, Color.black, false));
        }
    }
}