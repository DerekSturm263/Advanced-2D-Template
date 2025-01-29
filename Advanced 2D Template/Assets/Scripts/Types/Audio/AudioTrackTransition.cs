using System;
using UnityEngine;

namespace Types.Audio
{
    [Serializable]
    public struct AudioTrackTransition
    {
        [SerializeField] private string _to;
        public readonly string To => _to;

        [SerializeField] private AudioClip _clip;
        public readonly AudioClip Clip => _clip;

        [SerializeField] private float _length;
        public readonly float Length => _length;
    }
}
