using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Types.Input
{
    [Serializable]
    public struct InputButton
    {
        [SerializeField] private Collections.Dictionary<string, Sprite> _idsToIcons;
        public readonly string GetID(string controlName)
        {
            if (_idsToIcons.TryGetValue(controlName, out Sprite sprite) && sprite)
                return sprite.name;

            return string.Empty;
        }

        [SerializeField] private Collections.Dictionary<string, Sprite> _idsToIconsPositive;
        public readonly string GetIDPositive(string controlName)
        {
            if (_idsToIconsPositive.TryGetValue(controlName, out Sprite sprite) && sprite)
                return sprite.name;

            return string.Empty;
        }

        [SerializeField] private InputActionReference _action;
        public readonly InputActionReference Action => _action;
    }
}
