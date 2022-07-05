using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mario.Object
{
    public class Coin : BasicObject
    {
        [SerializeField]
        CoinInfo _playerCoinInfo;

        protected override void Rutin()
        {
            if (_playerCoinInfo.Coin < _playerCoinInfo.MaxCoin)
            {
                _playerCoinInfo.Coin++;
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                print("Coin: Player Enter");

                Rutin();
            }
        }
    }
}
