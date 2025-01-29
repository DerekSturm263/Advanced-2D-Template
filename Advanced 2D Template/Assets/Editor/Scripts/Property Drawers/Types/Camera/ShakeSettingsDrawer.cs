using UnityEditor;

namespace Types.Camera
{
    [CustomPropertyDrawer(typeof(ShakeSettings))]
    internal class ShakeSettingsDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_relativeVerticalCurve" },
            new string[] { "_relativeHorizontalCurve" },
            new string[] { "_length" },
            new string[] { "_strength" },
            new string[] { "_frequency" }
        };
    }
}
