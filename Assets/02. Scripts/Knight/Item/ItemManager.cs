using UnityEngine;
using UnityEngine.UI;

namespace _02._Scripts.Knight.Item
{
    public class ItemManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] items;
        [SerializeField] private Transform slotGroup; // Scroll View에서 Content
        [SerializeField] private Slot[] slots;
        [SerializeField] private GameObject inventoryUI;
        [SerializeField] private Button inventoryButton;
        private void Awake()
        {
            // 자신과 자식 중 해당 Component가 있는 대상을 모두 가져옴 (여기선 Slot Component 보유 대상)
            // Default: SetActive False인 경우 갖고오지 않음 (파라미터로 true 함께 전달)
            slots = slotGroup.GetComponentsInChildren<Slot>(true);
            inventoryButton.onClick.AddListener(OnInventory);
        }
        
        /// <summary>
        /// 랜덤으로 특정 Item 선택 후 생성(드롭) -> Knight가 위치로 가서 먹음 -> inventory에 등록 
        /// </summary>
        /// <param name="dropPos"></param>
        public void DropItem(Vector3 dropPos)
        {
            var item = Instantiate(items[Random.Range(0, items.Length)], dropPos, Quaternion.identity);
            var rb = item.GetComponent<Rigidbody2D>();

            rb.AddForceY(Random.Range(-2f, 2f), ForceMode2D.Impulse);
            rb.AddForceY(3f, ForceMode2D.Impulse);
            rb.AddTorque(Random.Range(-5f, 5f), ForceMode2D.Impulse); // 2D 에선 Z축 기준으로만 회전함
        }
        
        public void GetItem(IItemV2 item)
        {
            // 인벤토리에 Item 넣는 기능
            // Slot 중 비어있는 곳에 AddItem
            foreach (var slot in slots)
            {
                if (slot.isEmpty)
                {
                    slot.AddItem(item);
                    break;
                }
            }
        }
        
        private void OnInventory()
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
}