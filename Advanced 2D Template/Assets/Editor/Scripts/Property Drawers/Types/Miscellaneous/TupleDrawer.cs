using UnityEditor;

namespace Types.Miscellaneous
{
    [CustomPropertyDrawer(typeof(Tuple<,>))]
    internal class TupleDrawer : PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_item1" },
            new string[] { "_item2" }
        };
    }
}
