using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _maxHealth;
    private float _currentHealth;
    public bool IsDetected = false;

    private void Awake()
    {
        _maxHealth = 100;
        _currentHealth = _maxHealth;
    }



    public void TakeDamage(int damage) // Получение урона
    {
        _currentHealth -= damage;
        Debug.Log(_currentHealth);

        if (_currentHealth <= 0)
        {
            Destroy(this.gameObject);
        };
    }
}
