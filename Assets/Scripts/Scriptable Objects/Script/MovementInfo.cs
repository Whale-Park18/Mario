using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Movement Info")]
public class MovementInfo : ScriptableObject
{
    // 단위: m/s
    // 사람 평균: 5km/h = 약 1.4m/s
    // _moveSpeed * Time.deltaTime = m/s
    // _moveSpeed = 1초당 움직이는 "거리"
    [SerializeField]
    private float _moveSpeed;
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

    // 단위: m(점프 최고점 높이)
    // 사람 평균: 1m
    [SerializeField]
    private float _jumpPower;
    public float JumpPower { get { return _jumpPower; } set { _jumpPower = value; } }
}
