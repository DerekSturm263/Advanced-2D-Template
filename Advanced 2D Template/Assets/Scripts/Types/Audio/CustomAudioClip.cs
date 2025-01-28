using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Types.Audio
{
    [Serializable]
    public struct CustomAudioClip : Interfaces.ILerpable<CustomAudioClip>
    {
        [SerializeField] private List<AudioClip> _variants;
        public readonly AudioClip Clip => _variants[UnityEngine.Random.Range(0, _variants.Count)];

        [SerializeField] private AudioMixerGroup _mixer;
        public readonly AudioMixerGroup Mixer => _mixer;

        [SerializeField] private Miscellaneous.Range<float> _volumeRange;
        public readonly float Volume => UnityEngine.Random.Range(_volumeRange.Min, _volumeRange.Max);

        public readonly CustomAudioClip Lerp(CustomAudioClip b, float t)
        {
            return new()
            {
                _variants = _variants,
                _mixer = _mixer,
                _volumeRange = new(Mathf.Lerp(_volumeRange.Min, b._volumeRange.Min, t), Mathf.Lerp(_volumeRange.Max, b._volumeRange.Max, t))
            };
        }
    }
}
