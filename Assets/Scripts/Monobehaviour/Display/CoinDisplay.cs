using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mario.Display
{
    public class CoinDisplay : MonoBehaviour
    {
        [SerializeField]
        private CoinInfo _coinInfo;

        [SerializeField]
        private Text _coinText;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            _coinText.text = _coinInfo.Coin.ToString();
        }
    }
}