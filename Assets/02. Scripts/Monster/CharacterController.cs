using System;
using System.Collections;
using _02._Scripts.Monster.Item;
using UnityEngine;

namespace _02._Scripts.Monster
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private GameObject hitBox;
        [SerializeField] private float speed = 3f;
        private Animator _animator;
        private float _h, _v;
        private bool _isAttack = false;

        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            Attack();
            Move();
        }

        void Move()
        {
            _h = Input.GetAxis("Horizontal");
            _v = Input.GetAxis("Vertical");

            if (_h == 0 && _v == 0)
            {
                _animator.SetBool("Run", false);
            }
            else
            {
                var scaleX = _h > 0 ? 1 : -1;

                transform.localScale = new Vector3(scaleX, 1, 1);

                _animator.SetBool("Run", true);

                var dir = new Vector3(_h, _v, 0).normalized;
                transform.position += dir * (speed * Time.deltaTime);
            }
        }

        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !_isAttack)
            {
                StartCoroutine(AttackRoutine());
            }
        }

        IEnumerator AttackRoutine()
        {
            _isAttack = true;
            hitBox.SetActive(true);

            yield return new WaitForSeconds(0.25f);

            _isAttack = false;
            hitBox.SetActive(false);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            var monster = other.GetComponent<Monster>();

            if (monster)
            {
                // hit 실행
                StartCoroutine(monster.Hit(1));
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var item = other.gameObject.GetComponent<IItem>();
            
            // hit 실행
            item?.GetItem();
        }
    }
}