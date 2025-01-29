using ScriptableObjects.Wrappers;
using System;
using UnityEngine;

namespace Types.Wrappers
{
    [Serializable]
    public struct Nullable<T>
    {
        [SerializeField] private T _nonNullValue;
        public readonly T Value => _nonNullValue;

        [SerializeField] private bool _hasValue;
        public readonly bool HasValue => _hasValue;

        public Nullable(T value)
        {
            _nonNullValue = value;
            _hasValue = true;
        }

        public readonly T GetValueOrDefault()
        {
            if (_hasValue)
                return _nonNullValue;
            else
                return default;
        }

        public readonly T GetValueOrDefault(T defaultValue)
        {
            if (_hasValue)
                return _nonNullValue;
            else
                return defaultValue;
        }

        public readonly override bool Equals(object other)
        {
            if (other is null || other is not Nullable<T>)
                return false;

            return _nonNullValue.Equals(((Nullable<T>)other)._nonNullValue) && _hasValue.Equals(((Nullable<T>)other)._hasValue);
        }

        public readonly override int GetHashCode() => HashCode.Combine(_nonNullValue, _hasValue);
        public readonly override string ToString() => _nonNullValue.ToString();

        public static implicit operator Nullable<T>(T value) => new(value);
        public static explicit operator T(Nullable<T> value) => value.GetValueOrDefault();
    }
}
