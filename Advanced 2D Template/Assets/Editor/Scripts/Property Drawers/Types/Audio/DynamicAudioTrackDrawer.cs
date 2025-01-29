using UnityEditor;

namespace Types.Audio
{
    [CustomPropertyDrawer(typeof(DynamicAudioTrack))]
    internal class DynamicAudioTrackDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_sections" }
        };
    }
}
