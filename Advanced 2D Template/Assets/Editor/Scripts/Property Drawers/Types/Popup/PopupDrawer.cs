using UnityEditor;

namespace Types.Popup
{
    [CustomPropertyDrawer(typeof(Popup))]
    internal class PopupDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_title" },
            new string[] { "_description" },
            new string[] { "_responses" },
            new string[] { "_inputResponse" }
        };
    }
}
