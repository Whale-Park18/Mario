using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Movement Info")]
public class MovementInfo : ScriptableObject
{
    // ����: m/s
    // ��� ���: 5km/h = �� 1.4m/s
    // _moveSpeed * Time.deltaTime = m/s
    // _moveSpeed = 1�ʴ� �����̴� "�Ÿ�"
    [SerializeField]
    private float _moveSpeed;
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

    // ����: m(���� �ְ��� ����)
    // ��� ���: 1m
    [SerializeField]
    private float _jumpPower;
    public float JumpPower { get { return _jumpPower; } set { _jumpPower = value; } }
}
