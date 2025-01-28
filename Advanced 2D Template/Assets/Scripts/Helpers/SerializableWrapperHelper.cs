using UnityEngine;

namespace Helpers
{
    public static class SerializableWrapperHelper
    {
        public static RenderTexture IconRT, PreviewRT;

        public static void SetRTs(RenderTexture icon, RenderTexture preview)
        {
            IconRT = icon;
            PreviewRT = preview;
        }
    }
}
