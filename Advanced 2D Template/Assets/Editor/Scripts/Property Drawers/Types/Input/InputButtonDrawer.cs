using UnityEditor;

namespace Types.Input
{
    [CustomPropertyDrawer(typeof(InputButton))]
    internal class InputButtonDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_idsToIcons" },
            new string[] { "_idsToIconsPositive" },
            new string[] { "_action" }
        };
    }
}
