using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace SingletonBehaviours
{
    public class InputMapController : Types.SingletonBehaviour<InputMapController>
    {
        [SerializeField] private Types.Input.InputIconMapAsset _settings;
        public Types.Input.InputIconMapAsset Settings => _settings;

        private InputDevice _currentDevice;
        public InputDevice CurrentDevice => _currentDevice;

        public override void Initialize()
        {
            _currentDevice ??= InputSystem.devices.First(item => _settings.Value.HasControlScheme(item.displayName));
            InputSystem.onAnyButtonPress.Call(SetAllInputDevices);
        }

        public void SetAllInputDevices(InputControl action)
        {
            if (!_settings.Value.HasControlScheme(action.device.displayName))
                return;

            _currentDevice = action.device;

            foreach (MonoBehaviours.Input.ButtonPrompt prompt in FindObjectsByType<MonoBehaviours.Input.ButtonPrompt>(FindObjectsInactive.Include, FindObjectsSortMode.None))
            {
                prompt.DisplayInput(action.device);
            }
        }
    }
}
