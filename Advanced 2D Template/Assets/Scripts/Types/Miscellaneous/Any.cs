using System;
using System.Reflection;
using UnityEngine;

namespace Types.Miscellaneous
{
    [Serializable]
    public struct Any
    {
        public enum PropertyType
        {
            CSharpObject,
            UnityObject
        }

        [SerializeField] private PropertyType _type;

        [SerializeField] private string _typeName;
        public readonly Type Type => Type.GetType(_typeName);

        [SerializeReference] private object _cSharpObjValue;
        [SerializeField] private UnityEngine.Object _unityObjValue;

        private Any(Type type, object value)
        {
            _typeName = type.AssemblyQualifiedName;

            if (type.IsSubclassOf(typeof(UnityEngine.Object)))
                _type = PropertyType.UnityObject;
            else
                _type = PropertyType.CSharpObject;

            if (_type == PropertyType.UnityObject)
            {
                _unityObjValue = (UnityEngine.Object)value;
                _cSharpObjValue = null;
            }
            else
            {
                _cSharpObjValue = value;
                _unityObjValue = null;
            }
        }

        public readonly T Get<T>()
        {
            if (_type == PropertyType.UnityObject)
                return (T)(object)GetUnityObjValue();
            else
                return GetObjValue<T>();
        }

        private readonly T GetObjValue<T>()
        {
            try
            {
                if (_cSharpObjValue is not null)
                    return (T)_cSharpObjValue;
                else
                    return default;
            }
            catch
            {
                return default;
            }
        }
        private readonly UnityEngine.Object GetUnityObjValue()
        {
            if (_unityObjValue != null)
                return _unityObjValue;
            else
                return default;
        }

        public void Set<T>(T value)
        {
            if (typeof(T) != Type)
                throw new ArgumentException($"Given argument \"{typeof(T).Name}\" did not match the current type of the Any.");

            if (_type == PropertyType.UnityObject)
            {
                SetUnityObjValue((UnityEngine.Object)(object)value);
                _cSharpObjValue = null;
            }
            else
            {
                SetObjValue(value);
                _unityObjValue = null;
            }
        }

        private void SetObjValue<T>(T value) => _cSharpObjValue = value;
        private void SetUnityObjValue(UnityEngine.Object value) => _unityObjValue = value;

        public readonly bool IsNull
        {
            get
            {
                if (_type == PropertyType.UnityObject)
                    return _unityObjValue == null;
                else
                    return _cSharpObjValue == null;
            }
        }

        public static object GetDefault(Type type)
        {
            Type thisType = typeof(Any);
            MethodInfo method = thisType.GetMethod("GetDefaultGeneric", BindingFlags.NonPublic | BindingFlags.Static);
            method = method.MakeGenericMethod(type);
            object val = method.Invoke(null, null);

            return val;
        }

#pragma warning disable IDE0051 // Remove unused private members
        private static T GetDefaultGeneric<T>() => default;
#pragma warning restore IDE0051 // Remove unused private members

        public readonly override bool Equals(object obj)
        {
            if (obj is Any any)
            {
                if (_type == PropertyType.UnityObject)
                    if (_unityObjValue != null)
                        return _unityObjValue.Equals(any._unityObjValue);
                    else
                        return obj is null;
                else
                    return Equals(_cSharpObjValue, any._cSharpObjValue);
            }
            else
            {
                return false;
            }
        }

        public readonly override int GetHashCode() => System.HashCode.Combine(_type, _typeName, _cSharpObjValue, _unityObjValue);

        public static Any FromValue<T>(T value)
        {
            return new Any(typeof(T), value);
        }
    }
}
