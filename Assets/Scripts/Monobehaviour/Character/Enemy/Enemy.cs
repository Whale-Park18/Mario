using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Mario.Character.Enemy
{
    public abstract class BasicEnemy : BasicCharacter
    {
        //---------------------------------------
        // 상태 관련
        //---------------------------------------

        // 생존 상태 플래그
        protected bool _isLive = true;

        //---------------------------------------
        // 피해 위치
        //---------------------------------------

        // 피격 인정 위치
        [SerializeField]
        protected float _killPoint;

        // 피격 인정 위치 프로퍼티
        public float KillPoint { get { return _killPoint; } }

        //---------------------------------------
        // 이동 관련
        //---------------------------------------
        [SerializeField]
        protected Vector3[] _endPoints;
        protected int _endPointsIndex;
        [SerializeField]
        protected int _firstMovePointIndex;
    
        protected Vector3 _targetPosition;

        protected Vector3 _routeBackPoint;
        protected float _backPointDistance;

        //---------------------------------------
        // 코루틴 관련
        //---------------------------------------
        protected Coroutine _directionCoroutine;
        protected Coroutine _movementCoroutine;
        //protected Coroutine _damageCoroutine;
        protected Coroutine _attackCoroutine;

        /// <summary>
        /// 캐릭터 이동 함수
        /// </summary>
        /// <returns>코루틴</returns>
        protected abstract IEnumerator Move();

        /// <summary>
        /// 방향 전환 함수
        /// </summary>
        protected virtual void Turn()
        {
            transform.LookAt(transform.position + _direction);
        }

        /// <summary>
        /// 배회 함수
        /// </summary>
        /// <returns>코루틴</returns>
        protected abstract IEnumerator Wander();

        /// <summary>
        /// 공격할 수 있는지 확인하는 함수
        /// </summary>
        /// <returns>공격 가능 여부</returns>
        protected virtual bool CanAttack(float playerHeight)
        {
            return (playerHeight < _killPoint) && _isLive;
        }

        protected override IEnumerator Die()
        {
            _isLive = false;

            if (_directionCoroutine != null)
                StopCoroutine(_directionCoroutine);
            if (_movementCoroutine != null)
                StopCoroutine(_movementCoroutine);
            if (_attackCoroutine != null)
                StopCoroutine(_attackCoroutine);
            
            return base.Die();
        }
    }
}
