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
        // movement ����
        //---------------------------------------

        // �̵� ������ ���� ScriptableObject
        [SerializeField]
        protected MovementInfo _movementInfo;
        // �̵� ���� ����
        protected Vector3 _direction = Vector3.zero;

        //---------------------------------------
        // ������Ʈ
        //---------------------------------------
        
        // �ִϸ�����
        protected Animator _animator;
        // ������ٵ�
        protected Rigidbody _rigidbody;

        /// <summary>
        /// �ٸ� ������Ʈ���� Character ������Ʈ�� ���� ������Ʈ���� ���ظ� �� �� ȣ���ϴ� �Լ�
        /// </summary>
        /// <param name="damage">���� ��ġ</param>
        /// <param name="interval">���� �Է� ����</param>
        /// <returns>�ڷ�ƾ</returns>
        public abstract IEnumerator BeDamage(int damage);

        /// <summary>
        /// ĳ���Ͱ� ��� ���� �� ȣ��Ǵ� �Լ�
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
