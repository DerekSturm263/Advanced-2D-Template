using UnityEditor;

namespace Types.Casting
{
    [CustomPropertyDrawer(typeof(Caster))]
    internal class CasterDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_direction" },
            new string[] { "_maxDistance" },
            new string[] { "_layerMask" },
            new string[] { "_triggerInteraction" },
            new string[] { "_settings" }
        };
    }
}
