using UnityEngine;

namespace ScriptableObjects.Wrappers
{
    public abstract class Asset<T> : ScriptableObject
    {
        [SerializeField] private T _value;
        public T Value => _value;
    }
}
