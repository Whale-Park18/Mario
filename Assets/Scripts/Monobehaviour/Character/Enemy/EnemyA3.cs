using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mario.Character.Enemy
{
    /// <summary>
    /// 
    /// Ư¡
    ///     * �̵� Ÿ��: ����
    ///     * ����: O
    ///     * ����: ����(�浹)
    ///         * n ���� ����
    /// </summary>
    public class EnemyA3 : BasicEnemy
    {
        [SerializeField]
        private bool _onRightMode;

        // ���� �Ÿ�
        [SerializeField]
        private float _dashDistance;

        // ���� �ӵ�
        [SerializeField]
        private float _dashSpeed;

        // ���� ��� �ð�
        [SerializeField]
        private float _dashWaitTime;

        // �����
        [SerializeField]
        private int _hp;

        // �ּ� �����
        [SerializeField]
        private float _minHP;

        private GameObject _target;

        private void StatusUpdate(Status status)
        {
            _status = status;

            switch(_status)
            {
                case Status.Attack:
                    if (_directionCoroutine != null)
                        StopCoroutine(_directionCoroutine);
                    _directionCoroutine = StartCoroutine(Dash());
                    break;

                case Status.Move:
                    if (_directionCoroutine != null)
                        StopCoroutine(_directionCoroutine);
                    _directionCoroutine = StartCoroutine(Move());
                    break;
            }
        }

        public override IEnumerator BeDamage(int damage)
        {
            //_hp -= damage;
            //
            //if (_hp < _minHP)
            //{
            //    StartCoroutine(Die());
            //}

            yield return null;
        }

        private void SetDirection()
        {
            if (_onRightMode)
                _direction = -transform.forward;
            else
                _direction = transform.forward;

            //print(_direction);
        }

        /// <summary>
        /// �̵� �Լ�
        /// </summary>
        /// <returns></returns>
        protected override IEnumerator Move()
        {
            SetDirection();

            Turn();

            while(true)
            {
                transform.position += _direction * _movementInfo.MoveSpeed * Time.deltaTime;
                _animator.SetBool("isWalk", _direction != Vector3.zero);

                yield return null;
            }
        }

        /// <summary>
        /// �Ⱦ�
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override IEnumerator Wander()
        {
            throw new System.NotImplementedException();
        }

        private Vector3 GetDashDirection()
        {
            _targetPosition = _target.transform.position;

            Vector3 targetPosition = new Vector3(_targetPosition.x, 0, _targetPosition.z);
            Vector3 position = new Vector3(transform.position.x, 0, transform.position.z);

            return (targetPosition - position).normalized;
        }

        /// <summary>
        /// ���� �Լ�
        /// </summary>
        /// <returns></returns>
        private IEnumerator Dash()
        {
            //Vector3 tmpDirection = GetDashDirection();
            Vector3 tmpDirection = _direction;
            _direction = Vector3.zero;
            yield return new WaitForSeconds(_dashWaitTime - 0.14f);
            
            _animator.SetBool("isAttack", true);
            yield return new WaitForSeconds(0.14f);

            _direction = tmpDirection;
            for (float moveDistance = 0; _dashDistance >= moveDistance; moveDistance += _dashSpeed * _movementInfo.MoveSpeed * Time.deltaTime)
            {
                transform.position += _direction * _dashSpeed * _movementInfo.MoveSpeed * Time.deltaTime;

                yield return null;
            }

            _direction = Vector3.zero;
            _animator.SetBool("isAttack", false);

            StatusUpdate(Status.Move);
        }

        // Start is called before the first frame update
        void Start()
        {
            //_animator = transform.GetChild(0).GetComponent<Animator>();    
            _animator = GetComponentInChildren<Animator>();

            _directionCoroutine = StartCoroutine(Move());
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                //if(_movementCoroutine != null)
                //    StopCoroutine(_movementCoroutine);
                //
                //
                //_target = other.gameObject;
                //_directionCoroutine = StartCoroutine(Dash());

                _target = other.gameObject;
                StatusUpdate(Status.Attack);
            }
        }
    }
}
