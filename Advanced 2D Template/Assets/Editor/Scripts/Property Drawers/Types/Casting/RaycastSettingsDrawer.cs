using UnityEditor;

namespace Types.Casting
{
    [CustomPropertyDrawer(typeof(RaycastSettings))]
    internal class RaycastSettingsDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
        };
    }
}
