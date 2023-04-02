using UnityEngine;
using UnityEngine.UI;

public class JoystickInput : PlayerInput
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Button _fireButton;

    public override Vector2 Velocity => _joystick.Direction;

    private void OnEnable()
    {
        _fireButton.onClick.AddListener(OnFireButtonClick);
    }

    private void OnDisable()
    {
        _fireButton.onClick.RemoveListener(OnFireButtonClick);
    }

    private void OnFireButtonClick()
    {
        OnFire();
    }
}
