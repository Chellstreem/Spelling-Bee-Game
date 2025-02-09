using System.Collections.Generic;
using UnityEngine;

namespace Sounds
{
    public class SoundLibrary : ISoundLibrary
    {
        private readonly Dictionary<SoundType, AudioClip> soundMap;

        public SoundLibrary(SoundCollection soundCollection)
        {
            soundMap = new Dictionary<SoundType, AudioClip>();
            InitializeDictionary(soundCollection);
        }

        private void InitializeDictionary(SoundCollection soundCollection)
        {
            foreach (var sound in soundCollection.Sounds)
            {
                if (!soundMap.ContainsKey(sound.Type))
                {
                    soundMap.Add(sound.Type, sound.Clip);
                }
            }
        }

        public AudioClip GetClip(SoundType soundType)
        {
            return soundMap.TryGetValue(soundType, out var clip) ? clip : null;
        }
    }
}
