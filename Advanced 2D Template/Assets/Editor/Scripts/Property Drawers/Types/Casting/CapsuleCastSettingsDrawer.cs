using UnityEditor;

namespace Types.Casting
{
    [CustomPropertyDrawer(typeof(CapsuleCastSettings))]
    internal class CapsuleCastSettingsDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_points" },
            new string[] { "_radius" }
        };
    }
}
