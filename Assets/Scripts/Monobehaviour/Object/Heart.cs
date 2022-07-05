using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mario.Object
{
    public class Heart : BasicObject
    {
        [SerializeField]
        private HPInfo _playerHPInfo;

        protected override void Rutin()
        {
            if(_playerHPInfo.HP < _playerHPInfo.MaxHP)
            {
                _playerHPInfo.HP++;
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                Rutin();
            }
        }
    }
}
