using UnityEngine;
using UnityEngine.Audio;

namespace SingletonBehaviours
{
    public class AudioController : Types.SingletonBehaviour<AudioController>
    {
        private AudioSource _musicSource;

        private AudioSource CreateMusicSource()
        {
            AudioSource audioSource = new GameObject("Music Player").AddComponent<AudioSource>();

            audioSource.playOnAwake = false;
            audioSource.loop = true;
            audioSource.outputAudioMixerGroup = _musicGroup;

            DontDestroyOnLoad(audioSource.gameObject);
            return audioSource;
        }

        private AudioSource _sfxSource;

        private AudioSource CreateSFXSource()
        {
            AudioSource audioSource = new GameObject("SFX Player").AddComponent<AudioSource>();

            audioSource.playOnAwake = false;
            audioSource.outputAudioMixerGroup = _sfxGroup;

            DontDestroyOnLoad(audioSource.gameObject);
            return audioSource;
        }

        [SerializeField] private AudioMixerGroup _uiGroup;
        [SerializeField] private AudioMixerGroup _musicGroup;
        [SerializeField] private AudioMixerGroup _sfxGroup;

        public override void Initialize()
        {
            base.Initialize();

            if (!_musicSource)
                _musicSource = CreateMusicSource();

            if (!_sfxSource)
                _sfxSource = CreateSFXSource();
        }

        public override void Shutdown()
        {
            if (_musicSource)
                Destroy(_musicSource.gameObject);

            if (_sfxSource)
                Destroy(_sfxSource.gameObject);

            base.Shutdown();
        }

        public void PlayAudioClip(AudioClip clip)
        {
            if (!_sfxSource)
                return;

            Debug.Log($"{clip.name} played");
            _sfxSource.PlayOneShot(clip);
        }

        public void StopAudioClip() => _sfxSource.Stop();

        public void PlayAudioClipAsTrack(AudioClip clip)
        {
            _musicSource.clip = clip;
            PlayTrack();
        }

        // TODO: Uncomment
        /*public void SetTrack(TrackGraph track)
        {
            _musicSource.clip = track.GetUnityAsset().GetFromName("Normal").Clips[0];
        }*/

        public void PlayTrack()
        {
            if (!_musicSource.isPlaying)
                _musicSource.Play();
        }

        public void PauseTrack() => _musicSource.Pause();
        public void StopTrack() => _musicSource.Stop();

        public void EnableSnapshot(AudioMixerSnapshot snapshot) => snapshot.TransitionTo(0.33333f);
    }
}
