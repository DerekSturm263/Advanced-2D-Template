using System;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Types.Scene
{
    [Serializable]
    public struct SceneLoadSettings
    {
        [SerializeField] private SceneField _scene;
        public readonly SceneField Scene => _scene;

        [SerializeField] private AnimatorController _transition;
        public readonly AnimatorController Transition => _transition;

        [SerializeField] private LoadSceneParameters _loadParameters;
        public readonly LoadSceneParameters LoadParameters => _loadParameters;

        [SerializeField] private Collections.Dictionary<string, Types.Miscellaneous.Any> _sceneParameters;
        public readonly T GetSceneParameter<T>(string key) => (T)(object)_sceneParameters[key];
    }
}
