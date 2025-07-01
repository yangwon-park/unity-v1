using System;
using UnityEngine;

namespace _02._Scripts.Knight
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private float power;
        [SerializeField] private float speed;

        private Vector3 _initPos;
        private float _theta;

        private void Start()
        {
            _initPos = transform.position;
        }

        private void Update()
        {
            _theta += Time.deltaTime * speed;
            transform.position = new Vector3(_initPos.x + power * (Mathf.Sin(_theta)), _initPos.y, _initPos.z);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            other.transform.SetParent(transform);
        }
        
        private void OnCollisionExit2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            other.transform.SetParent(null);
        }
    }
}