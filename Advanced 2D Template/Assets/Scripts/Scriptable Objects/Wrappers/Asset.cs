using UnityEngine;

namespace ScriptableObjects.Wrappers
{
    public abstract class Asset<T> : ScriptableObject
    {
        [SerializeField] private T _value;
        public T Value => _value;
    }
    
    [CreateAssetMenu(fileName = "New Int Asset", menuName = "Numerical/Int")]
    public class IntAsset : Asset<int> { }

    [CreateAssetMenu(fileName = "New Float Asset", menuName = "Numerical/Float")]
    public class FloatAsset : Asset<float> { }

    [CreateAssetMenu(fileName = "New Double Asset", menuName = "Numerical/Double")]
    public class DoubleAsset : Asset<double> { }

    [CreateAssetMenu(fileName = "New Vector2 Asset", menuName = "Numerical/Vector 2")]
    public class Vector2Asset : Asset<Vector2> { }

    [CreateAssetMenu(fileName = "New Vector3 Asset", menuName = "Numerical/Vector 3")]
    public class Vector3Asset : Asset<Vector3> { }

    [CreateAssetMenu(fileName = "New Vector4 Asset", menuName = "Numerical/Vector 4")]
    public class Vector4Asset : Asset<Vector4> { }

    [CreateAssetMenu(fileName = "New Quaternion Asset", menuName = "Numerical/Quaternion")]
    public class QuaternionAsset : Asset<Quaternion> { }

    [CreateAssetMenu(fileName = "New String Asset", menuName = "Text/String")]
    public class StringAsset : Asset<string> { }

    [CreateAssetMenu(fileName = "New Bool Asset", menuName = "Logical/Bool")]
    public class BoolAsset : Asset<bool> { }
}
