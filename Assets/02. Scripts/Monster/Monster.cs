using System.Collections;
using UnityEngine;

namespace _02._Scripts.Monster
{
    public abstract class Monster : MonoBehaviour
    {
        private SpawnManager _spawnManager;
        private SpriteRenderer _sRenderer;
        private Animator _animator;

        [SerializeField] protected float hp = 3f;
        [SerializeField] protected float moveSpeed = 3f;

        private int _dir = 1;
        private bool _isMove = true;
        private bool _isHit = false;

        public abstract void Init();
        
        void Start()
        {
            _sRenderer = GetComponent<SpriteRenderer>(); // GetComponent -> GameObject가 갖고 있는 Component를 찾음
            _animator = GetComponent<Animator>();
            _spawnManager = FindFirstObjectByType<SpawnManager>(); // Scene에서 찾음

            Init();
        }

        void OnMouseDown()
        {
            // 클릭할 때 마다 Coroutine이 계속 동작함
            StartCoroutine(Hit(1));
        }

        void Update()
        {
            Move();
        }

        void Move()
        {
            if (!_isMove) return;

            transform.position += Vector3.right * (_dir * moveSpeed * Time.deltaTime);

            if (transform.position.x > 8f)
            {
                _dir = -1;
                _sRenderer.flipX = true;
            }
            else if (transform.position.x < -8f)
            {
                _dir = 1;
                _sRenderer.flipX = false;
            }
        }

        IEnumerator Hit(float damage)
        {
            if (_isHit) yield break; // Coroutine 즉시 종료하려면 break 써야함

            _isMove = false;
            _isHit = true;

            hp -= damage;

            if (hp <= 0)
            {
                _animator.SetTrigger("Death");
                _spawnManager.DropCoin(transform.position);
                
                yield return new WaitForSeconds(3f);
                Destroy(gameObject);

                yield break;
            }

            _animator.SetTrigger("Hit");

            yield return new WaitForSeconds(0.65f);

            _isMove = true;
            _isHit = false;
        }
    }
}