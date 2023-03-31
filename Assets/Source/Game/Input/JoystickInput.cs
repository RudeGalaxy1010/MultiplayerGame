using UnityEngine;

public class JoystickInput : PlayerInput
{
    [SerializeField] private Joystick _joystick;

    public override Vector2 Velocity => _joystick.Direction;
}
