using System.Collections;
using UnityEngine;

namespace _02._Scripts.Monster
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] monsters;
        [SerializeField] private GameObject[] items;

        // N초마다 몬스터 랜덤 스폰 기능
        IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(3f);
                
                var randomIndex = Random.Range(0, monsters.Length);
                var randomX = Random.Range(-8, 9);
                var randomY = Random.Range(-3, 6);
                
                var randomPos = new Vector3(randomX, randomY, 0);
                
                Instantiate(monsters[randomIndex], randomPos, Quaternion.identity);
            }
        }
        
        public void DropCoin(Vector3 dropPos)
        {
            var randomIndex = Random.Range(0, items.Length);
            
            Instantiate(items[randomIndex], dropPos, Quaternion.identity);
        }
    }
}