using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Types.Audio
{
    [Serializable]
    public struct DynamicAudioTrack
    {
        [SerializeField] private List<AudioTrackSection> _sections;
        public readonly List<AudioTrackSection> Sections => _sections;

        private Dictionary<string, AudioTrackSection> _sectionsByName;
        public void InitializeSectionsDictionary() => _sectionsByName = _sections.ToDictionary(item => item.Name);

        public readonly AudioTrackSection GetSectionFromName(string name)
        {
            if (_sectionsByName.TryGetValue(name, out AudioTrackSection value))
                return value;
            else
                return default;
        }

        private AudioTrackSection _currentSection;
        public readonly AudioTrackSection CurrentSection => _currentSection;
        public void SetCurrentSection(AudioTrackSection current) => _currentSection = current;

        private AudioTrackTransition _currentTransition;
        public readonly AudioTrackTransition CurrentTransition => _currentTransition;
        public void SetCurrentTransition(AudioTrackTransition currentTransition) => _currentTransition = currentTransition;
    }
}
