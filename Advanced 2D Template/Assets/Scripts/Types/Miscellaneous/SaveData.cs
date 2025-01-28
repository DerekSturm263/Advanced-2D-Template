using System;
using UnityEngine;

namespace Types.Miscellaneous
{
    [Serializable]
    public struct SaveData
    {
        [SerializeField] private Collections.Dictionary<string, Any> _data;
        public readonly T GetData<T>(string key) => (T)(object)_data[key];
    }

    [CreateAssetMenu(fileName = "New Save Data Asset", menuName = "Miscellaneous/Save Data")]
    public class SaveDataAsset : ScriptableObjects.Wrappers.Asset<SaveData> { }
}
