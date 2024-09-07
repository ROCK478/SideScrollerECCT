using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _maxHealth;
    private float _currentHealth;
    public bool IsDetected = false;
    private Rigidbody2D _rb;
    private Transform _player;
    [SerializeField] private float _rayDistance; //���������� ��� ������ ������

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _maxHealth = 100;
        _currentHealth = _maxHealth;
    }



    public void TakeDamage(int damage) // ��������� �����
    {
        _currentHealth -= damage;
        Debug.Log(_currentHealth);

        if (_currentHealth <= 0)
        {
            Destroy(this.gameObject);
        };
    }
}
