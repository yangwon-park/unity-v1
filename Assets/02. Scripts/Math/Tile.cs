using UnityEngine;

namespace _02._Scripts.Math
{
    public class Tile : MonoBehaviour
    {
        public GameObject[] turretPrefabs;
        
        void OnMouseDown()
        {
            Instantiate(turretPrefabs[GenerateTile.turretIndex], transform.position, Quaternion.identity);
        }
    }
}