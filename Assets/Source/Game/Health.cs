using Photon.Pun;
using System;
using UnityEngine;

public class Health : MonoBehaviourPun
{
    private const string DamageLessThanZeroMessage = "Damage can't be less or equal 0";

    public event Action HealthChanged;
    public event Action Died;

    [SerializeField] private int MaxHelath;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = MaxHelath;
    }

    public float HealthPerc => (float)_currentHealth / MaxHelath;

    [PunRPC]
    public void TakeDamage(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException(DamageLessThanZeroMessage);
        }

        _currentHealth -= value;
        HealthChanged?.Invoke();

        if (_currentHealth <= 0)
        {
            Died?.Invoke();
        }
    }
}
