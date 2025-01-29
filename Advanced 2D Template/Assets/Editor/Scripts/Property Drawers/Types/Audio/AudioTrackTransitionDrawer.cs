using UnityEditor;

namespace Types.Audio
{
    [CustomPropertyDrawer(typeof(AudioTrackTransition))]
    internal class AudioTrackTransitionDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_to" },
            new string[] { "_clip" },
            new string[] { "_length" }
        };
    }
}
