using UnityEngine;

namespace _02._Scripts.Monster.Item
{
    public class Heart : MonoBehaviour, IItem
    {
        private Inventory _inventory;
        public GameObject Obj { get; set; }

        void Start()
        {
            _inventory = FindFirstObjectByType<Inventory>();
            Obj = gameObject;
        }

        void OnMouseDown()
        {
            GetItem();
        }

        public void GetItem()
        {
            Debug.Log($"{name}을 획득했습니다.");
            gameObject.SetActive(false);
            _inventory.AddItem(this);
        }
    }
}