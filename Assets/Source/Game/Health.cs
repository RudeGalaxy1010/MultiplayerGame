using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const string DamageLessThanZeroMessage = "Damage can't be less or equal 0";

    public event Action HealthChanged;
    public event Action Died;

    [SerializeField] private int MaxHelath;

    private int _currentHealth;

    public void Construct()
    {
        _currentHealth = MaxHelath;
    }

    public float HealthPerc => (float)_currentHealth / MaxHelath;

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            throw new ArgumentException(DamageLessThanZeroMessage);
        }

        _currentHealth -= damage;
        HealthChanged?.Invoke();

        if (_currentHealth < 0)
        {
            Died?.Invoke();
        }
    }
}
