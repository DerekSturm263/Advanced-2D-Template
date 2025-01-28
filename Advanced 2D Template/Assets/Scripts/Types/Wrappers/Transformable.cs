using ScriptableObjects.Wrappers;
using System;
using UnityEngine;

namespace Types.Wrappers
{
    [Serializable]
    public struct Transformable<T>
    {
        [SerializeField] private T _value;
        public readonly T Value => _value;

        [SerializeField] private Vector3 _position;
        public readonly Vector3 Position => _position;

        [SerializeField] private Quaternion _rotation;
        public readonly Quaternion Rotation => _rotation;

        [SerializeField] private Vector3 _scale;
        public readonly Vector3 Scale => _scale;

        public Transformable(T value, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            _value = value;
            _position = position;
            _rotation = rotation;
            _scale = scale;
        }
    }

    public abstract class TransformableAsset<T> : Asset<Transformable<T>> { }
}
