using System.Collections;
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

        private float _traceDistance = 5f;
        private float _attackDistance = 3f;
        private bool _isAttack;
        
        private void Start()
        {
            Init(hp, speed,  attackDamage, attackCoolTime);

            StartCoroutine(FindPlayerRoutine());
        }
        private IEnumerator FindPlayerRoutine()
        {
            while (true)
            {
                // yield return new WaitForSeconds(0.02f); -> Frame 수 조절 (50fps)
                yield return null;
                
                // 내적
                // 두 오브젝트가 어떻게 바라보고 있는가 알 수 있음
                // Cosine 값을 가짐
                _targetDistance = Vector3.Distance(transform.position, _target.position);
            
                if (monsterState == MonsterState.Idle || monsterState == MonsterState.Patrol)
                {
                    var facingDirection = Vector3.right * _moveDirection;
                    var toTargetDirection = (transform.position - _target.position).normalized;
                    _isTrace = Vector3.Dot(facingDirection, toTargetDirection) < 0;
                    
                    if (_targetDistance <= _traceDistance && _isTrace)
                    {
                        _animator.SetBool("isRun", true);
                        ChangeState(MonsterState.Trace);
                    }
                    
                }
                else if (monsterState == MonsterState.Trace)
                {
                    if (_targetDistance > _traceDistance)
                    {
                        _timer = 0f;
                        _idleTime = Random.Range(1f, 5f);
                        _animator.SetBool("isRun", false);
                        
                        ChangeState(MonsterState.Idle);
                    }

                    if (_targetDistance < _attackDistance)
                    {
                        ChangeState(MonsterState.Attack);
                    }
                }
            }
        }

        protected override void Init(float hp, float speed, float attackDamage, float attackCoolTime)
        {
            base.Init(hp, speed, attackDamage, attackCoolTime);
        }

        protected override void Idle()
        {
            _timer += Time.deltaTime;
            
            if (_timer >= _idleTime)
            {
                _timer = 0f;
                _moveDirection = Random.Range(0, 2) == 1 ? 1 : -1;
                transform.localScale = new Vector3(_moveDirection, 1, 1);
                hpBar.transform.localScale = new Vector3(_moveDirection, 1, 1);
                
                _animator.SetBool("isRun", true);
                _patrolTime = Random.Range(1f, 5f);

                ChangeState(MonsterState.Patrol);
            }
        }

        protected override void Patrol()
        {
            transform.position += Vector3.right * (speed * _moveDirection * Time.deltaTime);
            
            _timer += Time.deltaTime;
            
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
            var targetDirection = (_target.position - transform.position).normalized;
            transform.position += Vector3.right * (speed * targetDirection.x * Time.deltaTime);

            var scaleX = targetDirection.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
            hpBar.transform.localScale = new Vector3(scaleX, 1, 1);
        }

        protected override void Attack()
        {
            if (_isAttack) return;
            StartCoroutine(AttackRoutine());
        }

        private IEnumerator AttackRoutine()
        {
            _isAttack = true;
            _animator.SetTrigger("Attack");
            var attackAnimationTime = _animator.GetCurrentAnimatorStateInfo(0).length;
            
            yield return new WaitForSeconds(attackAnimationTime);
            
            _animator.SetBool("isRun", false);
            
            var targetDirection = (_target.position - transform.position).normalized;
            var scaleX = targetDirection.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
            hpBar.transform.localScale = new Vector3(scaleX, 1, 1);
            
            yield return new WaitForSeconds(attackCoolTime - 1f);

            _isAttack = false;
            _animator.SetBool("isRun", true);
            ChangeState(MonsterState.Trace);
        }
    }
}