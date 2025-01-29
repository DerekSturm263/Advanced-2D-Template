using UnityEditor;

namespace Types.Casting
{
    [CustomPropertyDrawer(typeof(BoxCastSettings))]
    internal class BoxCastSettingsDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_offset" },
            new string[] { "_size" },
            new string[] { "_rotation" }
        };
    }
}
