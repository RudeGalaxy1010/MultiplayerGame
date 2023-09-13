using System;
using Source.Bootstrap;

namespace Source.Game
{
    public interface IPlayerHealth : IService
    {
        event Action HealthChanged;
        event Action Died;
        float HealthPerc { get; }
        void TakeDamage(int value);
    }
}
