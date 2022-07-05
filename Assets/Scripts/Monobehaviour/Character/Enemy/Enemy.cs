using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Mario.Character.Enemy
{
    public abstract class BasicEnemy : BasicCharacter
    {
        //---------------------------------------
        // ���� ����
        //---------------------------------------

        // ���� ���� �÷���
        protected bool _isLive = true;

        //---------------------------------------
        // ���� ��ġ
        //---------------------------------------

        // �ǰ� ���� ��ġ
        [SerializeField]
        protected float _killPoint;

        // �ǰ� ���� ��ġ ������Ƽ
        public float KillPoint { get { return _killPoint; } }

        //---------------------------------------
        // �̵� ����
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
        // �ڷ�ƾ ����
        //---------------------------------------
        protected Coroutine _directionCoroutine;
        protected Coroutine _movementCoroutine;
        //protected Coroutine _damageCoroutine;
        protected Coroutine _attackCoroutine;

        /// <summary>
        /// ĳ���� �̵� �Լ�
        /// </summary>
        /// <returns>�ڷ�ƾ</returns>
        protected abstract IEnumerator Move();

        /// <summary>
        /// ���� ��ȯ �Լ�
        /// </summary>
        protected virtual void Turn()
        {
            transform.LookAt(transform.position + _direction);
        }

        /// <summary>
        /// ��ȸ �Լ�
        /// </summary>
        /// <returns>�ڷ�ƾ</returns>
        protected abstract IEnumerator Wander();

        /// <summary>
        /// ������ �� �ִ��� Ȯ���ϴ� �Լ�
        /// </summary>
        /// <returns>���� ���� ����</returns>
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
