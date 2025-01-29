using UnityEditor;

namespace Types.Camera
{
    [CustomPropertyDrawer(typeof(CameraSettings))]
    internal class CameraSettingsDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_fov" },
            new string[] { "_translationSpeed" },
            new string[] { "_translationOffset" },
            new string[] { "_translationClamp" },
            new string[] { "_rotationSpeed" },
            new string[] { "_rotationOffset" },
            new string[] { "_rotationClamp" },
            new string[] { "_zoomOffset" },
            new string[] { "_zoomSpeed" },
            new string[] { "_zoomScale" }
        };
    }
}
