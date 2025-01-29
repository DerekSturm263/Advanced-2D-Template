using System;
using UnityEngine;

namespace Types.Input
{
    [Serializable]
    public struct InputIconMap
    {
        [SerializeField] private Collections.Dictionary<string, Tuple<TMPro.TMP_SpriteAsset, Sprite>> _controlSchemesToPrompts;

        public readonly bool HasControlScheme(string controlScheme) => _controlSchemesToPrompts.ContainsKey(controlScheme);

        public readonly TMPro.TMP_SpriteAsset GetSpriteAsset(string controlScheme) => _controlSchemesToPrompts[controlScheme].Item1;
        public readonly Sprite GetSprite(string controlScheme) => _controlSchemesToPrompts[controlScheme].Item2;
    }
}
