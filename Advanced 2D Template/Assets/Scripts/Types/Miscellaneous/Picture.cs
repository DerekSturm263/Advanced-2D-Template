using System;
using UnityEngine;

namespace Types.Miscellaneous
{
    [Serializable]
    public struct Picture : Interfaces.ISerializable
    {
        public readonly string GetFilePath() => $"{Application.persistentDataPath}/SaveData/Pictures";
    }
}
