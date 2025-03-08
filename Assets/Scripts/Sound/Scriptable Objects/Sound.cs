using UnityEngine;

[CreateAssetMenu(fileName = "Sound", menuName = "Scriptable Objects/Sound/Sound")]
public class Sound : ScriptableObject
{
    [SerializeField] private SoundType type;
    [SerializeField] private AudioClip clip;

    public SoundType Type => type;
    public AudioClip Clip => clip;
}
