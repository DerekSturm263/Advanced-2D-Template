using System;
using UnityEngine;
using UnityEngine.Events;
using Extensions;

namespace MonoBehaviours
{
    [RequireComponent(typeof(Camera))]
    public class ManualCameraController : Types.SingletonBehaviour<ManualCameraController>
    {
        [SerializeField] private Types.Camera.CameraSettingsAsset _settings;
        public void SetCameraSettings(Types.Camera.CameraSettingsAsset settings) => _settings = settings;

        [SerializeField] private Camera _cam;
        [SerializeField] private RenderTexture _picture;

        [SerializeField] private UnityEvent<Types.Miscellaneous.Picture> _onTakePicture;

        private InputSystem_Actions _controls;

        private Vector3 _rotation;

        private void Awake()
        {
            _controls = new();
        }

        private void Update()
        {
            transform.rotation = Quaternion.Euler(_rotation);
        }

        public void Move(Vector2 input)
        {
            if (input.magnitude < 0.1f)
                return;

            Vector3 direction = input;

            float dt = Time.unscaledDeltaTime;

            transform.Translate(direction * (dt * _settings.Value.TranslationSpeed), Space.Self);
        }

        public void Orbit(Vector2 input)
        {
            if (input.magnitude < 0.1f)
                return;

            float dt = Time.unscaledDeltaTime;

            _rotation.x -= input.y * dt * _settings.Value.RotationSpeed;
            _rotation.y += input.x * dt * _settings.Value.RotationSpeed;
        }

        public void Zoom(float input)
        {
            Vector3 direction = new(0, 0, input);

            float dt = Time.unscaledDeltaTime;

            transform.Translate(direction * (dt * _settings.Value.ZoomSpeed), Space.Self);
        }

        public void Tilt(float input)
        {
            float dt = Time.unscaledDeltaTime;

            _rotation.z -= input * dt * _settings.Value.RotationSpeed;
        }

        public void Snap()
        {
            Types.Wrappers.Serializable<Types.Miscellaneous.Picture> picture = new(default, Helpers.SerializationHelper.GetPath<Types.Miscellaneous.Picture>(), DateTime.Now.ToUniversalTime().ToString("U"), "", new string[] { }, new Types.Miscellaneous.Tuple<string, string>[] { });
            picture.Save();

            picture.CreateIcon(_cam);
            picture.CreatePreview(_cam);

            RenderTextureDescriptor descriptor = new(_picture.width, _picture.height, RenderTextureFormat.ARGB32, 8, 0, RenderTextureReadWrite.sRGB);
            RenderTexture pictureTexture = new(descriptor);

            _cam.RenderToScreenshot($"{Helpers.SerializationHelper.GetPath<Types.Miscellaneous.Picture>()}/{picture.ID}_PICTURE.png", pictureTexture, UnityExtensionMethods.ImageType.PNG, TextureFormat.RGBA32, true);

            _onTakePicture.Invoke(picture);
        }

        private void OnEnable()
        {
            _controls.Enable();

            _rotation = transform.rotation.eulerAngles;
        }

        private void OnDisable() => _controls.Disable();
    }
}
