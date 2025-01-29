using UnityEditor;

namespace Types.Audio
{
    [CustomPropertyDrawer(typeof(CustomAudioClip))]
    internal class CustomAudioClipDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_variants" },
            new string[] { "_mixer" },
            new string[] { "_volumeRange" }
        };
    }
}
