using UnityEditor;
using UnityEngine;

#nullable enable

namespace Types.Miscellaneous
{
    public struct PropertyDrawSettings
    {
        private readonly SerializedProperty[][] _properties;

        private float? _height;
        public float Height => _height ?? GetHeight();

        private float GetHeight()
        {
            if (_properties is null)
                return 0;

            float totalHeight = 0;

            for (int row = 0; row < _properties.Length; ++row)
            {
                float rowHeight = 0;

                for (int col = 0; col < _properties[row].Length; ++col)
                {
                    SerializedProperty prop = _properties[row][col];
                    float colHeight = EditorGUI.GetPropertyHeight(prop);

                    if (colHeight > rowHeight)
                        rowHeight = colHeight;
                }

                totalHeight += rowHeight + 2;
            }

            _height = totalHeight;
            return _height.Value;
        }

        public PropertyDrawSettings(SerializedProperty[][] properties)
        {
            _properties = properties;
            _height = null;
        }

        public PropertyDrawSettings(SerializedProperty parent, string[][] propertyNames) : this(ConvertNamesToProperties(parent, propertyNames)) { }

        private static SerializedProperty[][] ConvertNamesToProperties(SerializedProperty parent, string[][] propertyNames)
        {
            SerializedProperty[][] properties = new SerializedProperty[propertyNames.Length][];

            for (int row = 0; row < propertyNames.GetLength(0); ++row)
            {
                properties[row] = new SerializedProperty[propertyNames[row].GetLength(0)];

                for (int col = 0; col < propertyNames[row].GetLength(0); ++col)
                {
                    properties[row][col] = parent.FindPropertyRelative(propertyNames[row][col]);
                }
            }

            return properties;
        }

        public readonly void OnGUI(ref Rect position, string[][]? displayNames = null)
        {
            float originalX = position.x;

            for (int row = 0; row < _properties.Length; ++row)
            {
                float totalHeight = 0;
                position.x = originalX;

                for (int col = 0; col < _properties[row].Length; ++col)
                {
                    SerializedProperty prop = _properties[row][col];

                    float propWidth = position.width / _properties[row].Length;
                    float propHeight = EditorGUI.GetPropertyHeight(prop);

                    Rect rect = new(position.position, new(propWidth, propHeight));

                    if (displayNames is null)
                        EditorGUI.PropertyField(rect, prop);
                    else
                        EditorGUI.PropertyField(rect, prop, new GUIContent(displayNames[row][col]));

                    if (propHeight > totalHeight)
                        totalHeight = propHeight;

                    position.x += propWidth;
                }

                position.y += totalHeight + 2;
            }
        }
    }
}
