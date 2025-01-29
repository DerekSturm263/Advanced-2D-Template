using UnityEditor;

namespace Types.Wrappers
{
    [CustomPropertyDrawer(typeof(Transformable<>))]
    internal class PositionalDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_value" },
            new string[] { "_position" },
            new string[] { "_rotation" },
            new string[] { "_scale" }
        };
    }
}
