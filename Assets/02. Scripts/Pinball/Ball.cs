using System;
using UnityEngine;

namespace _02._Scripts.Pinball
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private PinballManager pinballManager;

        private void OnCollisionEnter2D(Collision2D other)
        {
            var score =
                other.gameObject.tag switch
                {
                    "Score10" => 10,
                    "Score30" => 30,
                    "Score50" => 50,
                    _ => 0
                };

            pinballManager.totalScore += score;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("GameOver"))
            {
                Debug.Log($"게임 종료, 최종 점수 :: {pinballManager.totalScore}");
            }
        }
    }
}