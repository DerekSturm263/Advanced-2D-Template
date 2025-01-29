using UnityEditor;
using UnityEngine;

namespace Types.Miscellaneous
{
    internal abstract class PropertyDrawerBase : PropertyDrawer
    {
        private PropertyDrawSettings? _properties = null;
        private bool _isFoldedOut;

        public abstract string[][] GetPropertyNames();

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _properties ??= new(property, GetPropertyNames());

            EditorGUI.BeginProperty(position, label, property);
            GUI.Box(position, "");

            position = new(position.position + new Vector2(8, 4), new Vector2(position.width, EditorGUIUtility.singleLineHeight) - new Vector2(8, 4));
            _isFoldedOut = EditorGUI.Foldout(new Rect(position.x + 10, position.y, position.width, position.height), _isFoldedOut, label, true);
            
            if (_isFoldedOut)
            {
                bool doIndent = property.propertyPath.Contains(".");
                position = new(position.position + new Vector2(doIndent ? 10 : 0, EditorGUIUtility.singleLineHeight), new(position.width - (doIndent ? 9 : 6), position.height));
                
                _properties?.OnGUI(ref position);
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => EditorGUIUtility.singleLineHeight + 8 +
            (_isFoldedOut ?
            _properties.GetValueOrDefault().Height :
            0);
    }
}
