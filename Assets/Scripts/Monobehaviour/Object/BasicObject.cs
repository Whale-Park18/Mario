using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicObject : MonoBehaviour
{
    [SerializeField]
    protected float _axysYOffset;

    protected void IDLE()
    {
        float height = Mathf.Sin(Time.time);
        if (height < float.Epsilon)
            height = -height;

        transform.position = new Vector3(transform.position.x, height + _axysYOffset, 0);
    }

    protected abstract void Rutin();

    // Update is called once per frame
    void Update()
    {
        IDLE();
    }
}
