using UnityEngine;

public interface ISoundLibrary
{
    public AudioClip GetClip(SoundType effectType);
}
