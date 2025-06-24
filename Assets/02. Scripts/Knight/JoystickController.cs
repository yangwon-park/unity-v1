using UnityEngine;
using UnityEngine.EventSystems;

namespace _02._Scripts.Knight
{
    public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private KnightJoystickController knightController;
        [SerializeField] private GameObject backgroundUI;
        [SerializeField] private GameObject handleUI;

        private Vector2 _startPos;

        private void Start()
        {
            backgroundUI.SetActive(false);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            backgroundUI.SetActive(true);
            backgroundUI.transform.position = eventData.position;
            _startPos = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var dragVector = eventData.position - _startPos;

            // Handle의 이동 범위를 제한함
            // Vector.normalized -> 크기를 1로 만듦 -> 방향만 남음
            handleUI.transform.position =
                _startPos + dragVector.normalized * Mathf.Min(dragVector.magnitude, 100f);

            knightController.HandleInput(dragVector.x, dragVector.y);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            knightController.HandleInput(0, 0);
            handleUI.transform.localPosition = Vector2.zero;
            backgroundUI.SetActive(false);
        }
    }
}