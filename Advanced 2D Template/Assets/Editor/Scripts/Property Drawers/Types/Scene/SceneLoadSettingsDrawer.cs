using UnityEditor;

namespace Types.Scene
{
    [CustomPropertyDrawer(typeof(SceneLoadSettings))]
    internal class SceneLoadSettingsDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_scene" },
            new string[] { "_transition" },
            new string[] { "_loadParameters" }
        };
    }
}
