using UnityEditor;

namespace Types.Input
{
    [CustomPropertyDrawer(typeof(InputIconMap))]
    internal class InputIconMapDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_controlSchemesToPrompts" }
        };
    }
}
