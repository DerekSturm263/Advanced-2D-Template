using UnityEditor;

namespace Types.Collections
{
    [CustomPropertyDrawer(typeof(EntropicList<>))]
    internal class EntropicListDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_possibilities" }
        };
    }
}
