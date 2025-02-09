using UnityEngine;

namespace Sounds
{
    public class SoundEffectPlayer : ISoundEffectPlayer
    {
        private readonly AudioSource audioSource;
        private readonly ISoundLibrary library;

        public SoundEffectPlayer(ISoundLibrary library)
        {
            audioSource = new GameObject("SoundEffectPlayer").AddComponent<AudioSource>();
            this.library = library;
        }

        public void PlayEffect(SoundType soundType)
        {            
            AudioClip clip = library.GetClip(soundType);
            if (clip != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
}
