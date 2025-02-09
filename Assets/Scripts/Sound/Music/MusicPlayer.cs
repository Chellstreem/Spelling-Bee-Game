using UnityEngine;

namespace Sounds
{
    public class MusicPlayer : IMusicPlayer
    {
        private readonly AudioSource audioSource;
        private readonly ISoundLibrary library;

        public MusicPlayer(ISoundLibrary library)
        {
            audioSource = new GameObject("MusicPlayer").AddComponent<AudioSource>();
            this.library = library;
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
    }
}