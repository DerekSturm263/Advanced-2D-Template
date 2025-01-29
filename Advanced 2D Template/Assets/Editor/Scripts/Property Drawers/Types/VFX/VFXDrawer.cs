using UnityEditor;

namespace Types.VFX
{
    [CustomPropertyDrawer(typeof(VFX))]
    internal class VFXDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_vfxObject" },
            new string[] { "_parent" },
            new string[] { "_followParent" },
            new string[] { "_offset" },
            new string[] { "_direction" },
            new string[] { "_scaleMultiplier" }
        };
    }
}
