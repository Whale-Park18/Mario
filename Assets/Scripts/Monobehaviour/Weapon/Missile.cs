using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mario.Weapon
{
    public class Missile : MonoBehaviour
    {
        public float _speed;
        public float _maxSpeed;
        Rigidbody _rigidbody;

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();   
        }

        // Update is called once per frame
        void Update()
        {
            //print(_rigidbody.velocity.magnitude);
        }

        private void FixedUpdate()
        {
            if (_rigidbody.velocity.magnitude >= _maxSpeed * _maxSpeed)
                return;

            _rigidbody.AddForce(transform.forward * _speed, ForceMode.Impulse);
        }
    }
}
