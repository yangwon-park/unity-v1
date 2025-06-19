using UnityEngine;

namespace _02._Scripts.Monster.Item
{
    public class Coin : MonoBehaviour, IItem
    {
        public enum CoinType
        {
            Gold,
            Green,
            Blue
        }
        public CoinType coinType;
        public GameObject Obj { get; set; }
        private Inventory _inventory;

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