using UnityEditor;

namespace Types.Multiplayer
{
    [CustomPropertyDrawer(typeof(Profile))]
    internal class ProfileDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_username" },
            new string[] { "_icon" },
            new string[] { "_level" }
        };
    }
}
