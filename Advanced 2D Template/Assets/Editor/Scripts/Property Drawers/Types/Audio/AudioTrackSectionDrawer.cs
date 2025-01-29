using UnityEditor;

namespace Types.Audio
{
    [CustomPropertyDrawer(typeof(AudioTrackSection))]
    internal class AudioTrackSectionDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_name" },
            new string[] { "_bpm" },
            new string[] { "_exitTime" },
            new string[] { "_keepActive" },
            new string[] { "_clips" },
            new string[] { "_defaultWeights" },
            new string[] { "_transitions" }
        };
    }
}
