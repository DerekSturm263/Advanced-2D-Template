using System;
using Types.Miscellaneous;
using UnityEngine;

namespace Types.VFX
{
    [Serializable]
    public struct VFX : Interfaces.ILerpable<VFX>
    {
        public enum ParentType
        {
            None,
            User
        }

        [SerializeField] private GameObject _vfxObject;
        public readonly GameObject VFXObject => _vfxObject;

        [SerializeField] private ParentType _parent;
        public readonly ParentType Parent => _parent;

        [SerializeField] private bool _followParent;
        public readonly bool FollowParent => _followParent;

        [SerializeField] private Vector3 _offset;
        public readonly Vector3 Offset => _offset;

        [SerializeField] private Vector3 _direction;
        public readonly Vector3 Direction => _direction;

        [SerializeField] private Vector3 _scaleMultiplier;
        public readonly Vector3 ScaleMultiplier => _scaleMultiplier;

        public readonly VFX Lerp(VFX b, float t)
        {
            return new()
            {
                _vfxObject = _vfxObject,
                _parent = _parent,
                _followParent = t < 0.5f ? _followParent : b._followParent,
                _offset = Vector3.Lerp(_offset, b._offset, t),
                _direction = Vector3.Lerp(_direction, b._direction, t),
                _scaleMultiplier = Vector3.Lerp(_scaleMultiplier, b._scaleMultiplier, t)
            };
        }
    }
}
