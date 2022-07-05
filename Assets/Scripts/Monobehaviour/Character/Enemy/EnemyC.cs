using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mario.Character.Enemy
{
    /// <summary>
    /// 
    /// 특징
    ///     * 이동 타입: 직선
    ///     * 추적: O
    ///     * 공격: 돌진(충돌)
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
