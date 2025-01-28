using System;
using UnityEngine.InputSystem;

namespace Callbacks
{
    public readonly struct GamepadCallbackContext<TControls> where TControls : IInputActionCollection2, IDisposable, new()
    {
        private readonly InputAction.CallbackContext _input;
        public readonly InputAction.CallbackContext Input => _input;

        private readonly Types.Multiplayer.LocalPlayer<TControls> _player;
        public readonly Types.Multiplayer.LocalPlayer<TControls> Player => _player;

        public GamepadCallbackContext(InputAction.CallbackContext input, Types.Multiplayer.LocalPlayer<TControls> player)
        {
            _input = input;
            _player = player;
        }
    }
}
