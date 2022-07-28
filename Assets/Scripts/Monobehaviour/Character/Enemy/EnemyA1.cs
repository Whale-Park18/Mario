using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mario.Character.Enemy
{

    /// <summary>
    /// �⺻ ����
    /// Ư¡
    ///     * �̵� Ÿ��: �պ���
    ///     * ����: X
    ///     * ����: �浹
    /// </summary>
    public class EnemyA1 : BasicEnemy
    {
        // �����
        [SerializeField]
        private int _hp;

        // �ּ� �����
        [SerializeField]
        private float _minHP;


        /// <summary>
        /// �̵� �Լ�
        /// </summary>
        /// <returns></returns>
        protected override IEnumerator Move()
        {
            float remainingDistance = (transform.position - _targetPosition).sqrMagnitude;
            while (remainingDistance > 1f)
            {
                Turn();

                transform.position += _direction * _movementInfo.MoveSpeed * Time.deltaTime;
                _animator.SetBool("isWalk", _direction != Vector3.zero);

                remainingDistance = (transform.position - _targetPosition).sqrMagnitude;

                yield return null;
            }

            _direction = Vector3.zero;
        }

        /// <summary>
        /// ��ȸ ���� ���� �Լ�
        /// </summary>
        protected void SetWanderDirection()
        {
            if (_endPointsIndex >= _endPoints.Length)
                _endPointsIndex = 0;

            _targetPosition = _endPoints[_endPointsIndex++];
            _direction = (_targetPosition - transform.position).normalized;
        }

        protected override IEnumerator Wander()
        {
            while(true)
            {
                SetWanderDirection();

                if (_movementCoroutine != null)
                    StopCoroutine(_movementCoroutine);

                _movementCoroutine = StartCoroutine(Move());
                yield return new WaitUntil(() => _direction == Vector3.zero);
            }
        }

        public override IEnumerator BeDamage(int damage)
        {
            _hp -= damage;

            if (_hp < _minHP)
            {
                StartCoroutine(Die());
            }

            yield return null;
        }

        private void Start()
        {
            _animator = transform.GetChild(0).GetComponent<Animator>();

            _endPointsIndex = _firstMovePointIndex;
            _directionCoroutine = StartCoroutine(Wander());
        }

        private void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                GameObject playerObject = collision.gameObject;

                if(playerObject == null)
                    return;

                Player player = collision.gameObject.GetComponent<Player>();
                Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();

                print(player.Height);

                if(CanAttack(player.Height))
                {
                    if(_attackCoroutine == null)
                    {
                        // ���� �ڷ�ƾ
                        _attackCoroutine = StartCoroutine(player.BeDamage(1));

                        // ���� �ǵ��
                        Vector3 direction = (-playerObject.transform.forward + playerObject.transform.up).normalized;
                        rigidbody.AddForce(direction * 5, ForceMode.Impulse);
                    }
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (_attackCoroutine != null)
                {
                    StopCoroutine(_attackCoroutine);
                    _attackCoroutine = null;
                }
            }
        }
    }
}
