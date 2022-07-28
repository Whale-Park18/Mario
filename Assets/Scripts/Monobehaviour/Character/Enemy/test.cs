using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    Vector3 _direction;

    
    public MovementInfo _movementInfo;

    // Start is called before the first frame update
    void Start()
    {
        _direction = -transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _direction * _movementInfo.MoveSpeed * Time.deltaTime;
    }
}
