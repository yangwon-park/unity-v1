using System;
using UnityEngine;
using UnityEngine.UI;

namespace _02._Scripts.Knight.Item
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Button slot;
        private IItemV2 _item;
        
        public bool isEmpty = true;
        
        private void Awake()
        {
            slot.onClick.AddListener(UseItem);
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
        
        public void UseItem()
        {
            if (_item == null) return;
            _item.Use();
            ClearSlot();
        }
        
        public void ClearSlot()
        {
            _item = null;
            isEmpty = true;
            slot.interactable = !isEmpty;
            image.gameObject.SetActive(!isEmpty);
        }
    }
}