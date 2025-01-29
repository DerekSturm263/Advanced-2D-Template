using UnityEditor;

namespace Types.Miscellaneous
{
    [CustomPropertyDrawer(typeof(Range<>))]
    internal class RangeDrawer : PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_min" },
            new string[] { "_max" }
        };
    }
}
