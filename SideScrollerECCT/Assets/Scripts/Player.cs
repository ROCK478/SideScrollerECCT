using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [Header("Настройки передвижения")]
    [SerializeField] private float _moveSpeed;
    private bool _lookRight = true;
    private Rigidbody2D _rb;
    private Animator _animator;

    [Header("Настройки прыжка")]
    [SerializeField] private float _jumpForce;
    private bool _isGround;
    [SerializeField] private float _rayDistance = 0.6f; //Расстояние для поиска земли для недоступности множественных прыжков


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
        Jump();
        

        _animator.SetFloat("xVelocity", Math.Abs(_rb.velocity.x));
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = (new Vector2(Input.GetAxis("Horizontal") * _moveSpeed, _rb.velocity.y));
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

    private void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rb.position, Vector2.down, _rayDistance, LayerMask.GetMask("Ground")); //У объектов нужно указать слой "Ground"
        if (hit.collider != null)
        {
            _isGround = true;
        }
        else
        {
            _isGround = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rb.AddForce(Vector2.up.normalized * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
