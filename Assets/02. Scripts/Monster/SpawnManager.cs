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

        public void DropItem(Vector3 dropPos)
        {
            var item = Instantiate(items[Random.Range(0, items.Length)], dropPos, Quaternion.identity);
            var rb = item.GetComponent<Rigidbody2D>();

            rb.AddForceY(Random.Range(-2f, 2f), ForceMode2D.Impulse);
            rb.AddForceY(3f, ForceMode2D.Impulse);
            rb.AddTorque(Random.Range(-5f, 5f), ForceMode2D.Impulse); // 2D 에선 Z축 기준으로만 회전함
        }
    }
}