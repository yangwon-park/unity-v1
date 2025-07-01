using System;
using System.Collections;
using UnityEngine;

namespace _02._Scripts.Knight
{
    public class Trampoline : MonoBehaviour
    {
        private Animator _animator;
        private Rigidbody2D _rb;
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            
            _rb = other.GetComponent<Rigidbody2D>();
            StartCoroutine(TrampolineRoutine());
        }
        
        IEnumerator TrampolineRoutine()
        {
            _rb.AddForceY(30f, ForceMode2D.Impulse);
            _animator.SetTrigger("Push");
            
            yield return new WaitForSeconds(1f);
        }
    }
}