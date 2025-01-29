using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace SingletonBehaviours
{
    [RequireComponent(typeof(Camera))]
    public class AutomaticCameraController : Types.SingletonBehaviour<AutomaticCameraController>
    {
        [SerializeField] private List<Types.Miscellaneous.Tuple<float, Transform>> _targets;

        [SerializeField] private Types.Camera.CameraSettingsAsset _settings;
        public void SetCameraSettings(Types.Camera.CameraSettingsAsset settings)
        {
            _settings = settings;

            if (settings.Value.Volume)
                _volume.sharedProfile = settings.Value.Volume;
        }

        private Volume _volume;
        private MonoBehaviours.ManualCameraController _manualMode;

        private Vector3 _targetPosition;
        private Quaternion _targetRotation;
        private float _calculatedZoom;
        private float _targetZoom;

        private Types.Camera.ShakeSettings _shakeSettings;
        private Vector2 _shakeDirection;

        private float _shakeTime;
        private Vector2 _shakeAmount;

        private Camera _cam;
        public Camera Cam => _cam;

        private Camera[] _internalCams;

        private void Awake()
        {
            _targetPosition = transform.position;
            _targetRotation = transform.rotation;

            _cam = GetComponent<Camera>();
            _volume = GetComponent<Volume>();
            _manualMode = GetComponent<MonoBehaviours.ManualCameraController>();

            _internalCams = GetComponentsInChildren<Camera>(true);
        }

        private void LateUpdate()
        {
            if (!_settings)
                return;

            float dt = Time.timeScale == 0 ? Time.unscaledDeltaTime : Time.deltaTime;

            CalculateTargetZoom(dt);
            CalculateTargetPosition();
            CalculateTargetRotation();
            CalculateShake();

            foreach (Camera cam in _internalCams)
            {
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, _settings.Value.FOV, dt * _settings.Value.TranslationSpeed);
            }

            ApplyPosition(dt);
            ApplyRotation(dt);

            if (_shakeTime > 0)
                _shakeTime -= dt;
        }

        private void CalculateTargetZoom(float dt)
        {
            float zoom = _settings.Value.ZoomOffset;
            _calculatedZoom = zoom;

            if (_targets.Count == 0)
                return;

            Vector3 firstPos = _targets[0].Item2.position;
            Vector3 lastPos = _targets[^1].Item2.position;

            float distance = Vector3.Distance(firstPos, lastPos);
            _calculatedZoom = zoom + distance * _settings.Value.ZoomScale;
            _targetZoom = Mathf.Lerp(_targetZoom, _calculatedZoom, dt * _settings.Value.ZoomSpeed);
        }

        private void CalculateTargetPosition()
        {
            Vector3 targetPosition = default;

            if (_targets.Count > 0 && _targets.Sum(item => item.Item1) > 0)
            {
                float targetCountWeight = 0;
                for (int i = 0; i < _targets.Count; ++i)
                {
                    targetPosition += _targets[i].Item2.position * _targets[i].Item1;
                    targetCountWeight += _targets[i].Item1;
                }

                targetPosition /= targetCountWeight;
            }
            else
            {
                targetPosition = Vector3.Lerp(_settings.Value.TranslationClamp.Min, _settings.Value.TranslationClamp.Max, 0.5f);
            }

            targetPosition.x = Mathf.Clamp(targetPosition.x, _settings.Value.TranslationClamp.Min.x, _settings.Value.TranslationClamp.Max.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, _settings.Value.TranslationClamp.Min.y, _settings.Value.TranslationClamp.Max.y);
            targetPosition.z = Mathf.Clamp(targetPosition.z, _settings.Value.TranslationClamp.Min.z, _settings.Value.TranslationClamp.Max.z);

            _targetPosition = targetPosition + _settings.Value.TranslationOffset + new Vector3(0, 0, -_targetZoom);
        }

        private void CalculateTargetRotation()
        {
            _targetRotation = Quaternion.Euler(_settings.Value.RotationOffset);
        }

        private void CalculateShake()
        {
            if (_shakeTime > 0)
            {
                float x = (_shakeSettings.EvaluateRelativeHorizontal((_shakeSettings.Length - _shakeTime) * _shakeSettings.Frequency) * _shakeSettings.Strength);
                float y = (_shakeSettings.EvaluateRelativeVertical((_shakeSettings.Length - _shakeTime) * _shakeSettings.Frequency) * _shakeSettings.Strength);

                _shakeAmount = (_shakeDirection * y) + (new Vector2(_shakeDirection.y, -_shakeDirection.x) * x);
            }
            else
            {
                _shakeAmount = default;
            }
        }

        private void ApplyPosition(float dt)
        {
            transform.position = Vector3.Lerp(transform.position, _targetPosition, dt * _settings.Value.TranslationSpeed) + (Vector3)_shakeAmount;
        }

        private void ApplyRotation(float dt)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, dt * _settings.Value.RotationSpeed);
        }

        public void SetTarget(Transform target)
        {
            _targets.Clear();
            _targets.Add(new(1, target));
        }

        public void SetTarget(string targetName)
        {
            if (_targets.Count > 0)
                return;

            GameObject target = GameObject.Find(targetName);

            _targets.Clear();
            _targets.Add(new(1, target.transform));
        }

        public void FocusTarget(int index)
        {
            if (index >= _targets.Count)
                return;

            for (int i = 0; i < _targets.Count; ++i)
            {
                if (i != index)
                    _targets[i] = new(0, _targets[i].Item2);
                else
                    _targets[i] = new(1, _targets[i].Item2);
            }
        }

        public void FocusTarget(string name)
        {
            int index = _targets.FindIndex(item => item.Item2.name == name);
            FocusTarget(index);
        }

        public void ResetAllWeights()
        {
            for (int i = 0; i < _targets.Count; ++i)
            {
                _targets[i] = new(1, _targets[i].Item2);
            }
        }

        public void ClearAllWeights()
        {
            for (int i = 0; i < _targets.Count; ++i)
            {
                _targets[i] = new(0, _targets[i].Item2);
            }
        }

        public void SetTargets(IEnumerable<Transform> targets)
        {
            _targets.Clear();
            _targets.AddRange(targets.Select(item => new Types.Miscellaneous.Tuple<float, Transform>(1, item)));
        }

        public void AddTarget(Transform target)
        {
            _targets.Add(new(1, target));
        }

        public void RemoveTarget(Transform target)
        {
            _targets.RemoveAll(item => item.Item2 == target);
        }

        public void ClearTargets()
        {
            _targets.Clear();
        }

        public void Shake(Types.Camera.ShakeSettingsAsset settings) => Shake(settings.Value, Vector2.one, true);
        public void ShakeNoHaptics(Types.Camera.ShakeSettingsAsset settings) => Shake(settings.Value, Vector2.one, false);

        public void Shake(Types.Camera.ShakeSettings settings, Vector2 direction, bool doHaptics)
        {
            _shakeSettings = settings;

            _shakeTime = _shakeSettings.Length;
            _shakeDirection = direction;

            if (doHaptics)
            {
                foreach (var player in PlayerJoinController.Instance.GetAllLocalPlayers(true))
                {
                    HapticsController.Instance.Rumble(player, _shakeSettings.Strength * 0.1f, 0.3f);
                }
            }
        }
    }
}
