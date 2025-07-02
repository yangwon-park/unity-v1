using System;
using UnityEngine;

namespace _02._Scripts.Knight.Item
{
    public class HpPotion : MonoBehaviour, IItemV2
    {
        public ItemManager Inventory { get; set; }
        public GameObject Obj { get; set; }
        public string Name { get; set; }
        public Sprite ItemSprite { get; set; }

        private void Start()
        {
            Inventory = FindFirstObjectByType<ItemManager>();
            Obj = gameObject;
            Name = name;
            ItemSprite  = GetComponent<SpriteRenderer>().sprite;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Get();
            }
        }

        public void Get()
        {
            gameObject.SetActive(false);
            Inventory.GetItem(this);
        }

        public void Use()
        {
            Debug.Log("Use Hp Potion");
        }
    }
}