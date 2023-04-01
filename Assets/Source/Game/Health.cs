using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const string DamageLessThanZeroMessage = "Damage can't be less or equal 0";

    public event Action<int> HealthChanged;
    public event Action Died;

    [SerializeField] private int MaxHelath;

    private int _health;

    public void Construct()
    {
        _health = MaxHelath;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            throw new ArgumentException(DamageLessThanZeroMessage);
        }

        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health < 0)
        {
            Died?.Invoke();
        }
    }
}
