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
    /// </summary>
    public class EnemyC : BasicEnemy
    {
        public override IEnumerator BeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerator Move()
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerator Wander()
        {
            throw new System.NotImplementedException();
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}