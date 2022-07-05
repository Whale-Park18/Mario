using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //---------------------------------------
    // 플레이어 관련
    //---------------------------------------
    [SerializeField]
    HPInfo _playerHPInfo;
    [SerializeField]
    CoinInfo _playerCoinInfo;

    private void PlayerInit()
    {
        _playerHPInfo.HP = 3;
        _playerCoinInfo.Coin = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
