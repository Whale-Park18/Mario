using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mario.Character.Enemy
{

    /// <summary>
    /// 기본 몬스터 강화형
    /// 특징
    ///     * 이동 타입: 왕복형
    ///     * 추적: O
    ///     * 공격: 충돌
    /// </summary>
    public class EnemyB : EnemyA
    {
        private GameObject _target;

        /// <summary>
        /// 추적 방향 설정 함수
        /// </summary>
        private void SetTraceDirection()
        {
            _targetPosition = _target.transform.position;

            Vector3 targetPosition = new Vector3(_targetPosition.x, 0, _targetPosition.z);
            Vector3 position = new Vector3(transform.position.x, 0, transform.position.z);

            _direction = (targetPosition - position).normalized;
        }

        /// <summary>
        /// 추적 함수
        /// </summary>
        /// <returns>코루틴</returns>
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
        /// 타겟과 자신이 거리를 계산하는 함수
        /// </summary>
        /// <param name="targetPosition">타겟 위치</param>
        /// <returns>거리</returns>
        private float Distance(Vector3 targetPosition)
        {
            return (targetPosition - transform.position).sqrMagnitude;
        }

        /// <summary>
        /// 복귀 방향 설정 함수
        /// </summary>
        private void SetReturnDirection()
        {
            _targetPosition = Distance(_endPoints[0]) <= Distance(_endPoints[1]) ? _endPoints[0] : _endPoints[1];
            _direction = (_targetPosition - transform.position).normalized;
        }

        /// <summary>
        /// 복귀 함수
        /// </summary>
        /// <returns>코루틴</returns>
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
                // 추적 코루틴
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
