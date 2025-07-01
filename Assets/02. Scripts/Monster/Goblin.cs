using _02._Scripts.Knight;
using UnityEngine;

namespace _02._Scripts.Monster
{
    public class Goblin : MonsterCore
    {
        private float _timer;
        private float _idleTime;
        private float _patrolTime;
        private float _percent;
        // private Vector3 _startPosition;
        // private Vector3 _endPosition;
        
        private void Start()
        {
            Init(hp, speed);
        }

        protected override void Init(float hp, float speed)
        {
            base.Init(hp, speed);
            
            Debug.Log("Goblin init");
        }

        protected override void Idle()
        {
            _timer += Time.deltaTime;
            
            if (_timer >= _idleTime)
            {
                _timer = 0f;
                _direction = Random.Range(0, 2) == 1 ? 1 : -1;
                transform.localScale = new Vector3(_direction, 1, 1);
                _animator.SetBool("isRun", true);
                
                _patrolTime = Random.Range(1f, 5f);
                // _startPosition = transform.position;
                // _endPosition = _startPosition + Vector3.right * (_direction * _patrolTime);

                ChangeState(MonsterState.Patrol);
            }
        }

        protected override void Patrol()
        {
            transform.position += Vector3.right * (speed * _direction * Time.deltaTime);
            
            _timer += Time.deltaTime;
            // _percent = (_timer / _patrolTime) * speed;
            // transform.position = Vector3.Lerp(_startPosition, _endPosition, _percent);
            
            if (_timer >= _patrolTime)
            {
                _timer = 0f;
                _idleTime = Random.Range(1f, 5f);
                _animator.SetBool("isRun", false);
            
                ChangeState(MonsterState.Idle);
            }
        }

        protected override void Trace()
        {
            Debug.Log("Trace");
        }

        protected override void Attack()
        {
            Debug.Log("Attack");
        }
    }
}