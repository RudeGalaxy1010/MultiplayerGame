using System;
using UnityEngine;

public abstract class PlayerInput : MonoBehaviour
{
    public event Action FireButtonPressed;
    public abstract Vector2 Velocity { get; }

    protected void OnFire()
    {
        FireButtonPressed?.Invoke();
    }
}
