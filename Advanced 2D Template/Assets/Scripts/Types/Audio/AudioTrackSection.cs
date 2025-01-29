using System;
using System.Collections.Generic;
using UnityEngine;

namespace Types.Audio
{
    [Serializable]
    public struct AudioTrackSection
    {
        [SerializeField] private string _name;
        public readonly string Name => _name;

        [SerializeField] private int _bpm;
        public readonly int BPM => _bpm;

        [SerializeField] private float _exitTime;
        public readonly float ExitTime => _exitTime;

        [SerializeField] private bool _keepActive;
        public readonly bool KeepActive => _keepActive;

        [SerializeField] private List<AudioClip> _clips;
        public readonly List<AudioClip> Clips => _clips;

        [SerializeField] private List<float> _defaultWeights;
        public readonly List<float> DefaultWeights => _defaultWeights;

        [SerializeField] private List<AudioTrackTransition> _transitions;
        public readonly List<AudioTrackTransition> Transitions => _transitions;
    }
}
