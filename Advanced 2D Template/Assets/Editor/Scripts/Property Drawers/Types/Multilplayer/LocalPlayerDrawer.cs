using UnityEditor;

namespace Types.Multiplayer
{
    [CustomPropertyDrawer(typeof(LocalPlayer<>))]
    internal class LocalPlayerDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {

        };
    }
}
