using UnityEditor;

namespace Types.Dialogue
{
    [CustomPropertyDrawer(typeof(Dialogue))]
    internal class DialogueDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_dialogues" },
            new string[] { "_eventDelay" },
            new string[] { "_onDialogueEnd" }
        };
    }
}
