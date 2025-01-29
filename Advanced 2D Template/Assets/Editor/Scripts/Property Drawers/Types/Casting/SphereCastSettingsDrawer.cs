using UnityEditor;

namespace Types.Casting
{
    [CustomPropertyDrawer(typeof(SphereCastSettings))]
    internal class SphereCastSettingsDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_offset" },
            new string[] { "_radius" }
        };
    }
}
