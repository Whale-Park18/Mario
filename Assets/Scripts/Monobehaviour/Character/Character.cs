using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mario.Character
{
    enum Layer
    {
        Player = 8,
        Die = 10,
        OverPower = 11
    }

    public abstract class BasicCharacter : MonoBehaviour
    {

        //---------------------------------------
        // movement 관련
        //---------------------------------------

        // 이동 정보를 담은 ScriptableObject
        [SerializeField]
        protected MovementInfo _movementInfo;
        // 이동 방향 벡터
        protected Vector3 _direction = Vector3.zero;

        //---------------------------------------
        // 컴포넌트
        //---------------------------------------
        
        // 애니메이터
        protected Animator _animator;
        // 리지드바디
        protected Rigidbody _rigidbody;

        /// <summary>
        /// 다른 오브젝트에서 Character 컴포넌트를 가진 오브젝트에게 피해를 줄 때 호출하는 함수
        /// </summary>
        /// <param name="damage">피해 수치</param>
        /// <param name="interval">피해 입력 간격</param>
        /// <returns>코루틴</returns>
        public abstract IEnumerator BeDamage(int damage);

        /// <summary>
        /// 캐릭터가 사망 했을 때 호출되는 함수
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerator Die()
        {
            _animator.SetTrigger("doDie");
            gameObject.layer = (int)Layer.Die;

            yield return new WaitForSeconds(3.5f);

            Destroy(gameObject);
        }
    }
}
