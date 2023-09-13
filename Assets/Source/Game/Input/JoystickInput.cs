using System;
using Source.Assets;
using Source.Bootstrap;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Source.Game.Input
{
    public class JoystickInput : IPlayerInput, ISubscribeHandler
    {
        private readonly MobileInput _mobileMobileInput;

        public event Action FireButtonPressed;
        public Vector2 Velocity => _mobileMobileInput.Joystick.Direction;

        public JoystickInput(IAssetsProvider assetsProvider)
        {
            _mobileMobileInput = Object.Instantiate(assetsProvider.MobileInput());
        }
        
        public void Subscribe()
        {
            _mobileMobileInput.FireButton.onClick.AddListener(OnFireButtonClick);
        }

        public void Unsubscribe()
        {
            _mobileMobileInput.FireButton.onClick.RemoveListener(OnFireButtonClick);
        }

        private void OnFireButtonClick()
        {
            FireButtonPressed?.Invoke();
        }
    }
}
