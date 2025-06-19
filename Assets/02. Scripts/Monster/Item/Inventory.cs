using System.Collections.Generic;
using UnityEngine;

namespace _02._Scripts.Monster.Item
{
    public class Inventory : MonoBehaviour
    {
       // 획득한 아이템을 담아둘 공간이 필요
       // 현재 Inspector 상으로 확인위해 편의상 SF 추가
       [SerializeField] private List<GameObject> items;
       // [SerializeField] private List<IItem> items; // 이러면 Inspector에 노출되지 않음
    
       public void AddItem(IItem item)
       {
           items.Add(item.Obj);
       }
       
    }
}