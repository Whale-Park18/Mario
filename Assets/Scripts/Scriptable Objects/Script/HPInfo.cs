using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="HP Info")]
public class HPInfo : ScriptableObject
{
    [SerializeField]
    private int _hp;
    public int HP { get { return _hp; } set { _hp = value; } }

    [SerializeField]
    private int _maxHP;
    public int MaxHP { get { return _maxHP; } }

    [SerializeField]
    private int _minHP;
    public int MinHP { get { return _minHP; } }
}
