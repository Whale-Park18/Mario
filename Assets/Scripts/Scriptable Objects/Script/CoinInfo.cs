using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Coin Info")]
public class CoinInfo : ScriptableObject
{
    [SerializeField]
    private int _coin;
    public int Coin { get { return _coin; } set { _coin = value; } }

    [SerializeField]
    private int _maxCoin;
    public int MaxCoin { get { return _maxCoin; } }

    [SerializeField]
    private int _minCoin;
    public int MinCoin { get { return _minCoin; } }
}
