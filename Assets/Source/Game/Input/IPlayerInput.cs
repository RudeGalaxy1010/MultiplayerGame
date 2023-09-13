using System;
using Source.Bootstrap;
using UnityEngine;

namespace Source.Game.Input
{
    public interface IPlayerInput : IService
    {
        public event Action FireButtonPressed;
        public Vector2 Velocity { get; }
    }
}
