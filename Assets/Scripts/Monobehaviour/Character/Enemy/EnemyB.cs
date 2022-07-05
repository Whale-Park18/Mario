using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mario.Character.Enemy
{

    /// <summary>
    /// �⺻ ���� ��ȭ��
    /// Ư¡
    ///     * �̵� Ÿ��: �պ���
    ///     * ����: O
    ///     * ����: �浹
    /// </summary>
    public class EnemyB : EnemyA
    {
        private GameObject _target;

        /// <summary>
        /// ���� ���� ���� �Լ�
        /// </summary>
        private void SetTraceDirection()
        {
            _targetPosition = _target.transform.position;

            Vector3 targetPosition = new Vector3(_targetPosition.x, 0, _targetPosition.z);
            Vector3 position = new Vector3(transform.position.x, 0, transform.position.z);

            _direction = (targetPosition - position).normalized;
        }

        /// <summary>
        /// ���� �Լ�
        /// </summary>
        /// <returns>�ڷ�ƾ</returns>
        private IEnumerator Trace()
        {
            if(_isLive)
            {
                if(_movementCoroutine != null)
                    StopCoroutine(_movementCoroutine);

                _movementCoroutine = StartCoroutine(Move());

                while(true)
                {
                    SetTraceDirection();

                    yield return new WaitForSeconds(0.3f);
                }
            }
        }

        /// <summary>
        /// Ÿ�ٰ� �ڽ��� �Ÿ��� ����ϴ� �Լ�
        /// </summary>
        /// <param name="targetPosition">Ÿ�� ��ġ</param>
        /// <returns>�Ÿ�</returns>
        private float Distance(Vector3 targetPosition)
        {
            return (targetPosition - transform.position).sqrMagnitude;
        }

        /// <summary>
        /// ���� ���� ���� �Լ�
        /// </summary>
        private void SetReturnDirection()
        {
            _targetPosition = Distance(_endPoints[0]) <= Distance(_endPoints[1]) ? _endPoints[0] : _endPoints[1];
            _direction = (_targetPosition - transform.position).normalized;
        }

        /// <summary>
        /// ���� �Լ�
        /// </summary>
        /// <returns>�ڷ�ƾ</returns>
        private IEnumerator Return()
        {
            if(_isLive)
            {
                SetReturnDirection();

                if (_movementCoroutine != null)
                    StopCoroutine(_movementCoroutine);

                _movementCoroutine = StartCoroutine(Move());
                yield return new WaitUntil(() => _direction == Vector3.zero);

                _directionCoroutine = StartCoroutine(Wander());
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                // ���� �ڷ�ƾ
                if (_directionCoroutine != null)
                    StopCoroutine(_directionCoroutine);

                _target = other.gameObject;
                _directionCoroutine = StartCoroutine(Trace());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (_directionCoroutine != null)
                {
                    StopCoroutine(_directionCoroutine);
                    _direction = Vector3.zero;
                }
                _directionCoroutine = StartCoroutine(Return());
            }
        }
    }
}
