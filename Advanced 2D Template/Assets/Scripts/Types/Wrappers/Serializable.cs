using System;
using System.IO;
using UnityEngine;
using Extensions;

namespace Types.Wrappers
{
    [Serializable]
    public struct Serializable<T> where T : Interfaces.ISerializable
    {
        public static readonly Vector2Int IconDimensions = new(512, 512);
        public static readonly Vector2Int PreviewDimensions = new(1920, 1080);

        [SerializeField] private T _value;
        public readonly T Value => _value;

        [SerializeField] private string _directory;

        [SerializeField] private string _name;
        public readonly string Name => _name;
        public void SetName(string name) => _name = name;

        [SerializeField][TextArea] private string _description;
        public readonly string Description => _description;
        public void SetDescription(string description) => _description = description;

        [SerializeField] private long _creationDate;
        public readonly DateTime CreationDate => new(_creationDate);

        [SerializeField] private long _lastEditedDate;
        public readonly DateTime LastEditedDate => new(_lastEditedDate);
        public void SetLastEditedDate(long lastEditedDate) => _lastEditedDate = lastEditedDate;

        [SerializeField] private string _id;
        public readonly string ID => _id;

        [SerializeField] private bool _madeByPlayer;
        public readonly bool MadeByPlayer => _madeByPlayer;

        [SerializeField] private Sprite _iconOverride;
        public void SetIconOverride(Sprite iconOverride) => _iconOverride = iconOverride;

        private Sprite _icon;
        public Sprite Icon
        {
            get
            {
                if (_iconOverride)
                    return _iconOverride;

                if (!_icon)
                    _icon = Helpers.UnityHelper.SpriteFromScreenshot($"{_directory}/{ID}_ICON.png", IconDimensions.x, IconDimensions.y, TextureFormat.RGBA32, true, null);
                else
                    Debug.Log("Icon already exists!");

                return _icon;
            }
        }

        [SerializeField] private Sprite _previewOverride;

        private Sprite _preview;
        public Sprite Preview
        {
            get
            {
                if (_previewOverride)
                    return _previewOverride;

                if (!_preview)
                    _preview = Helpers.UnityHelper.SpriteFromScreenshot($"{_directory}/{ID}_PREVIEW.png", PreviewDimensions.x, PreviewDimensions.y, TextureFormat.RGBA32, true, null);
                else
                    Debug.Log("Preview already exists!");

                return _preview;
            }
        }

        [SerializeField] private string[] _filterTags;
        public readonly string[] FilterTags => _filterTags;

        [SerializeField] private Miscellaneous.Tuple<string, string>[] _groupTags;
        public readonly Miscellaneous.Tuple<string, string>[] GroupTags => _groupTags;

        public readonly bool IsValid => _id != string.Empty;

        public Serializable(T value, string directory, string name, string description, string[] filterTags, Miscellaneous.Tuple<string, string>[] groupTags)
        {
            _value = value;
            _directory = directory;
            _name = name;
            _description = description;
            _creationDate = DateTime.Now.Ticks;
            _lastEditedDate = DateTime.Now.Ticks;
            _id = Guid.NewGuid().ToString();
            _madeByPlayer = true;
            _iconOverride = null;
            _icon = null;
            _previewOverride = null;
            _preview = null;
            _filterTags = filterTags;
            _groupTags = groupTags;
        }

        public readonly void CreateIcon(UnityEngine.Camera camera, Shader shader = null, RenderTexture output = null, bool flipX = false)
        {
            camera.RenderToScreenshot($"{_directory}/{ID}_ICON.png", output ?? Helpers.SerializableWrapperHelper.IconRT, UnityExtensionMethods.ImageType.PNG, TextureFormat.RGBA32, true, flipX, shader);
        }

        public readonly void CreatePreview(UnityEngine.Camera camera, Shader shader = null, RenderTexture output = null)
        {
            camera.RenderToScreenshot($"{_directory}/{ID}_PREVIEW.png", output ?? Helpers.SerializableWrapperHelper.PreviewRT, UnityExtensionMethods.ImageType.PNG, TextureFormat.RGBA32, true, false, shader);
        }

        public readonly void Save()
        {
            Helpers.SerializationHelper.Save(this, _id.ToString(), _directory);
        }

        public readonly void Delete()
        {
            Helpers.SerializationHelper.Delete($"{_directory}/{_id}.json", _directory);

            if (File.Exists($"{_directory}/{_id}_ICON.png"))
                File.Delete($"{_directory}/{_id}_ICON.png");

            if (File.Exists($"{_directory}/{_id}_PREVIEW.png"))
                File.Delete($"{_directory}/{_id}_PREVIEW.png");
        }

        public static implicit operator T(Serializable<T> lhs)
        {
            return lhs._value;
        }

        public override readonly bool Equals(object obj)
        {
            if (obj is not Serializable<T>)
                return false;

            return ((Serializable<T>)obj)._id.Equals(_id);
        }

        public override readonly int GetHashCode()
        {
            System.HashCode hash = new();

            hash.Add(_id);

            return hash.ToHashCode();
        }

        public override readonly string ToString() => _value.ToString();
    }

    public abstract class SerializableAsset<T> : ScriptableObjects.Wrappers.Asset<Serializable<T>> where T : Interfaces.ISerializable { }
}
