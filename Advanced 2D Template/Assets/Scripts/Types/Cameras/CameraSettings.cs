using System;
using UnityEngine;

namespace Types.Camera
{
    [Serializable]
    public struct CameraSettings : Interfaces.ILerpable<CameraSettings>
    {
        [SerializeField] private int _fov;
        public readonly int FOV => _fov;

        [SerializeField] private float _translationSpeed;
        public readonly float TranslationSpeed => _translationSpeed;

        [SerializeField] private Vector3 _translationOffset;
        public readonly Vector3 TranslationOffset => _translationOffset;

        [SerializeField] private Miscellaneous.Range<Vector3> _translationClamp;
        public readonly Miscellaneous.Range<Vector3> TranslationClamp => _translationClamp;

        [SerializeField] private float _rotationSpeed;
        public readonly float RotationSpeed => _rotationSpeed;

        [SerializeField] private Vector3 _rotationOffset;
        public readonly Vector3 RotationOffset => _rotationOffset;

        [SerializeField] private Miscellaneous.Range<Vector3> _rotationClamp;
        public readonly Miscellaneous.Range<Vector3> RotationClamp => _rotationClamp;

        [SerializeField] private float _zoomOffset;
        public readonly float ZoomOffset => _zoomOffset;

        [SerializeField] private float _zoomSpeed;
        public readonly float ZoomSpeed => _zoomSpeed;

        [SerializeField] private float _zoomScale;
        public readonly float ZoomScale => _zoomScale;

        public readonly CameraSettings Lerp(CameraSettings b, float t)
        {
            return new()
            {
                _fov = (int)Mathf.Lerp(_fov, b._fov, t),
                _translationSpeed = Mathf.Lerp(_translationSpeed, b._translationSpeed, t),
                _translationOffset = Vector3.Lerp(_translationOffset, b._translationOffset, t),
                _translationClamp = new(Vector3.Lerp(_translationClamp.Min, b._translationClamp.Min, t), Vector3.Lerp(_translationClamp.Max, b._translationClamp.Max, t)),
                _rotationSpeed = Mathf.Lerp(_rotationSpeed, b._rotationSpeed, t),
                _rotationOffset = Vector3.Lerp(_rotationOffset, b._rotationOffset, t),
                _rotationClamp = new(Vector3.Lerp(_rotationClamp.Min, b._rotationClamp.Min, t), Vector3.Lerp(_rotationClamp.Max, b._rotationClamp.Max, t)),
                _zoomOffset = Mathf.Lerp(_zoomOffset, b._zoomOffset, t),
                _zoomSpeed = Mathf.Lerp(_zoomSpeed, b._zoomSpeed, t),
                _zoomScale = Mathf.Lerp(_zoomScale, b._zoomScale, t)
            };
        }
    }

    [CreateAssetMenu(fileName = "New Camera Settings Asset", menuName = "Camera/Camera Settings")]
    public class CameraSettingsAsset : ScriptableObjects.Wrappers.Asset<CameraSettings> { }
}
