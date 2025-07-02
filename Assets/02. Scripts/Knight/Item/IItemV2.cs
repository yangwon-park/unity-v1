using UnityEngine;

namespace _02._Scripts.Knight.Item
{
    public interface IItemV2
    {
        ItemManager Inventory { get; set; }
        GameObject Obj { get; set; }
        string Name { get; set; }
        Sprite ItemSprite { get; set; }

        void Get();
        void Use();
    }
}