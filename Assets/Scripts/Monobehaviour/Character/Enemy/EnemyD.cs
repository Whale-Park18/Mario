using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mario.Character.Enemy
{
    /// <summary>
    /// 보스
    /// 특징
    ///     * 이동 타입: 왕복형
    ///     * 추적: O
    ///     * 공격
    ///         * 충돌
    ///         * 돌진(최대 3연속)
    ///         * 충격파
    /// </summary>
    public class EnemyD : BasicEnemy
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
