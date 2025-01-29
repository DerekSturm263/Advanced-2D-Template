using UnityEditor;

namespace Types.Dialogue
{
    [CustomPropertyDrawer(typeof(DialoguePiece))]
    internal class DialoguePieceDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_speaker" },
            new string[] { "_text" },
            new string[] { "_speed" },
            new string[] { "_textEffect" },
            new string[] { "_onDialogue" },
            new string[] { "_responses" }
        };
    }
}
