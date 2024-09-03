using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    [Header("Настройки передвижения")]
    [SerializeField] private float _moveSpeed;
    private bool _lookRight = true;
    private Rigidbody2D _rb;
    private Animator _animator;


    [Header("Настройки стрельбы")]
    [SerializeField] private GameObject _bulletPrephab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _timeLifeBullet;
    private Transform _firePoint;



    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _firePoint = GameObject.Find("FirePoint").transform;
    }
    private void Update()
    {
        Flip();
        Shoot();

        _animator.SetFloat("xVelocity", Math.Abs(_rb.velocity.x));
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = new Vector2(Input.GetAxis("Horizontal"), _rb.velocity.y) * _moveSpeed;
    }

    private void Flip()
    {
        if ((_lookRight && (Input.GetAxis("Horizontal") < 0)) || (!_lookRight && (Input.GetAxis("Horizontal") > 0)))
        {
            gameObject.
            transform.localScale *= new Vector2(-1, 1);
            _lookRight = !_lookRight;
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject Bullet = Instantiate(_bulletPrephab, _firePoint.position, _firePoint.rotation);
            Rigidbody2D BulletRB = Bullet.GetComponent<Rigidbody2D>();
            if (_lookRight)
            {
                BulletRB.velocity = new Vector2(_bulletSpeed, 0);
            }
            else
            {
                BulletRB.velocity = new Vector2(_bulletSpeed * -1, 0);
            }
            Destroy(Bullet, _timeLifeBullet);
        }
    }
}
