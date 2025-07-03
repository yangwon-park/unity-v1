using UnityEngine;

namespace _02._Scripts.Knight.Item
{
    public interface IItemV2
    {
        ItemManager Inventory { get; set; }
        GameObject Obj { get; set; }
        string Name { get; set; }
        Sprite Image { get; set; }

        void Get();
        void Use();
    }
}