using System;
using System.Linq;
using UnityEngine;

namespace Types.Scene
{
    [Serializable]
    public struct SceneField
    {
#if UNITY_EDITOR

        [SerializeField] private UnityEngine.Object _sceneAsset;

#endif
        [SerializeField] private string _name;

        public SceneField(UnityEngine.Object sceneAsset, string name)
        {
            _sceneAsset = sceneAsset;
            _name = name;
        }

        public string Name
        {
            readonly get => _name;
            set => SetByName(value);
        }

        public static implicit operator string(SceneField sceneField)
        {
            return sceneField == null ? "" : sceneField.Name;
        }

        private void SetByName(string name)
        {
#if UNITY_EDITOR

            var scenePath = UnityEditor.EditorBuildSettings.scenes
                .Select(s => s.path)
                .FirstOrDefault(s => s.EndsWith(name + ".unity"));

            _sceneAsset = UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEditor.SceneAsset>(scenePath);

#endif
            _name = name;
        }
    }
}
