using UnityEngine;

namespace _02._Scripts.Monster.Item
{
    public interface IItem
    {
        GameObject Obj { get; set; }
        
        void GetItem();
    }
}