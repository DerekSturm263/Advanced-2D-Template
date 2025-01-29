using UnityEditor;
using UnityEngine;

namespace Types.Scene
{
    [CustomPropertyDrawer(typeof(SceneField))]
    internal class SceneFieldPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, GUIContent.none, property);

            SerializedProperty sceneAsset = property.FindPropertyRelative("_asset");
            SerializedProperty sceneName = property.FindPropertyRelative("_name");

            position = EditorGUI.PrefixLabel(position, label);

            if (sceneAsset != null)
            {
                EditorGUI.BeginChangeCheck();
                Object value = EditorGUI.ObjectField(position, sceneAsset.objectReferenceValue, typeof(SceneAsset), false);

                if (EditorGUI.EndChangeCheck())
                {
                    sceneAsset.objectReferenceValue = value;

                    if (sceneAsset.objectReferenceValue != null)
                        sceneName.stringValue = (sceneAsset.objectReferenceValue as SceneAsset).name;
                    else
                        sceneName.stringValue = "";
                }
            }

            EditorGUI.EndProperty();
        }
    }
}
