using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mario.Character.Enemy;

namespace Mario.Character
{
    public class Player : BasicCharacter
    {
        //---------------------------------------
        // 체력 관련
        //--------------------------------------
        [SerializeField]
        protected HPInfo _hpInfo;
        public HPInfo HpInfo { get { return _hpInfo; } }

        //---------------------------------------
        // 입력 관련
        // Z: forward
        // X: right
        // Y: up
        //---------------------------------------
        private float _inputUp;
        private float _inputRight;

        //---------------------------------------
        // movement 관련
        //---------------------------------------
        public Transform _cameraTransform;

        //---------------------------------------
        // Jump 관련
        //---------------------------------------
        [SerializeField]
        private ushort _maxJumpCount = 2;
        private ushort _jumpCount;
        private bool _jumpFlag;

        //---------------------------------------
        // 공격 관련
        //---------------------------------------
        [SerializeField]
        private ushort _killJumpPower; // 공격 성공시 발생한 점프 파워

        // 캐릭터의 높이 반환
        public float Height { get { return transform.position.y; } }

        //---------------------------------------
        // 피격 관련
        //---------------------------------------
        [SerializeField]
        private Material _material; // 피격 시, 캐릭터 반짝임 효과를 위한 머터리얼
        [SerializeField]
        private float _interval;    // 피격 시, 무적 시간

        //---------------------------------------
        // 코루틴 관련
        //---------------------------------------
        private Coroutine _beDamageEffectCoroutine;

        private void SetInputValue()
        {
            _inputUp = Input.GetAxisRaw("Vertical");
            _inputRight = Input.GetAxisRaw("Horizontal");
        }

        private void Move()
        {
            _direction = _cameraTransform.right.normalized * _inputRight;
            transform.position += _direction * _movementInfo.MoveSpeed * Time.deltaTime;

            _animator.SetBool("isWorking", _direction != Vector3.zero);
        }

        private void Turn()
        {
            transform.LookAt(transform.position + _direction);
        }

        private void Jump()
        {
            if(Input.GetButtonDown("Jump"))
            {
                if(_jumpCount < _maxJumpCount)
                {
                    _jumpFlag = true;
                    _animator.SetBool("isJumpping", _jumpFlag);
                    _animator.SetTrigger("doJumpping");

                    _jumpCount++;
                    _rigidbody.AddForce(transform.up * _movementInfo.JumpPower, ForceMode.Impulse);
                }
            }
        }

        private IEnumerator BeDamageEffect()
        {
            for (float time = 0; time <= _interval; time += 1)
            {
                _material.color = new Color(255/255f, 160/255f, 160/255f);
                yield return new WaitForSeconds(0.5f);
                _material.color = Color.white;
                yield return new WaitForSeconds(0.5f);
            }
        }

        private IEnumerator OverPowerMode(float timeLimit)
        {
            gameObject.layer = (int)Layer.OverPower;

            yield return new WaitForSeconds(timeLimit);

            gameObject.layer = (int)Layer.Player;
        }

        public override IEnumerator BeDamage(int damage)
        {
            print("Player BeDamge");

            while(true)
            {
                _hpInfo.HP -= damage;

                if(_hpInfo.HP < _hpInfo.MinHP)
                {
                    StartCoroutine(Die());
                    break;
                }

                if (_interval > float.Epsilon)
                {
                    //_beDamageEffectCoroutine = StartCoroutine(BeDamageEffect());
                    //yield return new WaitForSeconds(_interval);
                    //StopCoroutine(_beDamageEffectCoroutine);

                    StartCoroutine(BeDamageEffect());
                    StartCoroutine(OverPowerMode(_interval));
                    yield return new WaitForSeconds(_interval);
                }
                else
                {
                    break;
                }
            }

        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = transform.Find("Mesh Object").GetComponent<Animator>();
        }

        private void Update()
        {
            SetInputValue();

            Move();
            Turn();
            Jump();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Floor")
            {
                _jumpFlag = false;
                _animator.SetBool("isJumpping", _jumpFlag);

                _jumpCount = 0;
            }

            if(collision.gameObject.tag == "Enemy")
            {
                BasicEnemy enemy = collision.gameObject.GetComponent<BasicEnemy>();

                if (enemy == null)
                    return;

                // 공격 코드
                if(transform.position.y >= enemy.KillPoint)
                {
                    _rigidbody.AddForce(transform.up * _killJumpPower, ForceMode.Impulse);
                    _animator.SetTrigger("doJumpping");

                    StartCoroutine(enemy.BeDamage(1));
                }
            }
        }
    }
}
