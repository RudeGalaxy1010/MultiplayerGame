using System;
using Photon.Pun;
using UnityEngine;

namespace Source.Game
{
    public class Health : MonoBehaviourPun, IPlayerHealth
    {
        private const string DamageLessThanZeroMessage = "Damage can't be less or equal 0";

        public event Action HealthChanged;
        public event Action Died;

        [SerializeField] private int _maxHelath;

        private int _currentHealth;

        private void Start()
        {
            _currentHealth = _maxHelath;
        }

        public float HealthPerc => (float)_currentHealth / _maxHelath;

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

}
