using UnityEditor;

namespace Types.Miscellaneous
{
    [CustomPropertyDrawer(typeof(SaveData))]
    internal class SaveDataDrawer : PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_data" }
        };
    }
}
