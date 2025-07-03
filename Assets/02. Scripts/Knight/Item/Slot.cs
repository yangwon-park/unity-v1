using System;
using UnityEngine;
using UnityEngine.UI;

namespace _02._Scripts.Knight.Item
{
    public class Slot : MonoBehaviour
    {
        private IItemV2 _item;
        [SerializeField] private Image image;
        [SerializeField] private Button slot;

        public bool isEmpty = true;

        private void Awake()
        {
            slot = GetComponent<Button>();
            slot.onClick.AddListener(UseItem);
            
            image = transform.GetChild(0).GetComponent<Image>();
        }

        private void OnEnable()
        {
            slot.interactable = !isEmpty;
            image.gameObject.SetActive(!isEmpty);
        }

        // Inventory에서 실행
        public void AddItem(IItemV2 item)
        {
            _item = item;
            image.sprite = item.Image;
            image.SetNativeSize();
            isEmpty = false;
        }

        private void UseItem()
        {
            if (_item == null) return;
            _item.Use();
            ClearSlot();
        }

        private void ClearSlot()
        {
            _item = null;
            isEmpty = true;
            slot.interactable = !isEmpty;
            image.gameObject.SetActive(!isEmpty);
        }
    }
}