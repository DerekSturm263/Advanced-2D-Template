using System;

namespace Callbacks
{
    public readonly struct PopupCallbackContext
    {
        private readonly Action _action;
        public readonly void Invoke() => _action?.Invoke();

        public PopupCallbackContext(Action action)
        {
            _action = action;
        }
    }
}
