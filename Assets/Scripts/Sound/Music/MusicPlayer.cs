using UnityEngine;

namespace Sounds
{
    public class MusicPlayer : IMusicPlayer
    {
        private readonly ISoundLibrary library;
        private AudioSource audioSource;        

        public MusicPlayer(ISoundLibrary library)
        {
            this.library = library;
            CreateAudioSource();            
        }

        public void PlaySound(SoundType soundType)
        {
            if (audioSource.isPlaying) audioSource.Stop();
            audioSource.clip = library.GetClip(soundType);
            audioSource.Play();
        }

        public void StopSound(SoundType soundType)
        {
            if (!audioSource.isPlaying || audioSource.clip != library.GetClip(soundType))
            {
                return;
            }

            audioSource.Stop();
        }

        public void StopSound()
        {
            if (audioSource.isPlaying) audioSource.Stop();
        }

        private void CreateAudioSource()
        {
            audioSource = new GameObject("MusicPlayer").AddComponent<AudioSource>();
            audioSource.loop = true;
        }
    }
}