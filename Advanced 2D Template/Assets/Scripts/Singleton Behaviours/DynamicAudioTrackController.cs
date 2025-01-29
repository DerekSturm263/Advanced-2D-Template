using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace SingletonBehaviours
{
    public class DynamicTrackController : Types.SingletonBehaviour<DynamicTrackController>
    {
        /*[SerializeField] private float _endDelay = 0.5f + (17.0f / 60);
        [SerializeField] private AudioMixerGroup _musicGroup;

        private GameObject _obj;
        private GameObject CreateObj() => new("Stage Music Player");

        private Types.Audio.DynamicAudioTrack _track;
        private bool _isTransitioning;
        private float _transitionTime;
        private Types.Audio.AudioTrackSection _from;

        private Types.Collections.Dictionary<Types.Audio.AudioTrackSection, List<AudioSource>> _trackSources;

        public void SetupTrack(Types.Audio.DynamicAudioTrack track)
        {
            _track = track;

            _isTransitioning = false;
            _transitionTime = 0;
            _from = null;

            _track.InitializeSectionsDictionary();
            _track.SetCurrentSection(null);
            _track.SetCurrentTransition(null);

            if (_obj)
                Destroy(_obj);

            _trackSources = new();
            _obj = CreateObj();

            foreach (Types.Audio.AudioTrackSection trackSection in _track.Sections)
            {
                GameObject section = new(trackSection.name);
                section.transform.parent = _obj.transform;
                _trackSources.Add(trackSection, new());

                int i = 0;
                foreach (AudioClip clip in trackSection.Clips)
                {
                    AudioSource source = section.AddComponent<AudioSource>();

                    source.clip = clip;
                    source.outputAudioMixerGroup = _musicGroup;
                    source.volume = trackSection.DefaultWeights[i];
                    source.loop = true;

                    _trackSources[trackSection].Add(source);
                    ++i;
                }

                section.SetActive(false);
            }
        }

        private void FixedUpdate()
        {
            List<float> weights = _track.CurrentSection.CalculateWeights(_entityViewUpdater);
            for (int i = 0; i < _trackSources[_track.CurrentSection].Count; ++i)
            {
                _trackSources[_track.CurrentSection][i].volume = weights[i];
            }

            if (_isTransitioning)
            {
                _transitionTime += Time.fixedDeltaTime;

                if (_transitionTime >= _track.CurrentTransition.Length)
                    EndTransition(_from, _track.CurrentTransition);
                else
                    UpdateTransition(_from, _track.CurrentTransition, _transitionTime);
            }
            else
            {
                if (_track.CurrentSection.ExitTime > 0 && _trackSources[_track.CurrentSection][0].time >= _track.CurrentSection.ExitTime)
                    BeginTransition(_track.CurrentSection, _track.CurrentSection.Transitions[0]);
            }
        }

        public void Play(Types.Audio.DynamicAudioTrack track)
        {
            SetupTrack(track);
        }

        private void BeginTransition(TrackSection from, TrackTransition transition)
        {
            _transitionTime = 0;
            _trackSources[_track.GetFromName(transition.To)][0].gameObject.SetActive(true);
            _track.SetCurrentTransition(transition);

            _from = _track.CurrentSection;
            _track.SetCurrentSection(_track.GetFromName(transition.To));

            if (transition.Clip != null)
                AudioSource.PlayClipAtPoint(transition.Clip, Vector3.zero);

            foreach (var source in _trackSources[from])
            {
                source.volume = 1;
            }
            foreach (var source in _trackSources[_track.GetFromName(transition.To)])
            {
                source.volume = 0;
            }

            _isTransitioning = true;
        }

        private void UpdateTransition(TrackSection from, TrackTransition transition, float t)
        {
            foreach (var source in _trackSources[from])
            {
                source.volume = 1 - t * (1 / transition.Length);
            }

            int i = 0;
            List<float> weights = _track.CurrentSection.CalculateWeights(_entityViewUpdater);

            foreach (var source in _trackSources[_track.GetFromName(transition.To)])
            {
                source.volume = t * (1 / transition.Length) * weights[i];
                ++i;
            }
        }

        private void EndTransition(TrackSection from, TrackTransition transition)
        {
            foreach (var source in _trackSources[_track.GetFromName(transition.To)])
            {
                source.volume = 1;
            }

            if (from.KeepActive)
            {
                foreach (AudioSource audioSource in _trackSources[from])
                {
                    audioSource.volume = 0;
                }
            }
            else
            {
                _trackSources[from][0].gameObject.SetActive(false);
            }

            _isTransitioning = false;
        }

        public void ForceTransition(string name)
        {
            if (!_track)
                return;

            if (_track.CurrentSection is not null && _trackSources.TryGetValue(_track.CurrentSection, out List<AudioSource> audioSources))
            {
                audioSources[0].gameObject.SetActive(false);
            }

            TrackSection section = _track.GetFromName(name);
            if (section is null)
                return;

            _track.SetCurrentSection(section);
            _trackSources[_track.CurrentSection][0].gameObject.SetActive(true);

            TrackEventController.Instance.ResetFrame();
        }

        public void ForceTransitionSmooth(string name)
        {
            TrackTransition to = _track.CurrentSection.Transitions.Find(item => item.To == name);
            if (to is null)
                return;

            BeginTransition(_track.CurrentSection, to);
        }

        public void GetBPM(Extensions.Types.ReturningUnityEvent<int>.Resolver resolver)
        {
            if (_track && _track.CurrentSection is not null)
                resolver.SetReturnValue(_track.CurrentSection.BPM);
            else
                resolver.SetReturnValue(60);
        }*/
    }
}
