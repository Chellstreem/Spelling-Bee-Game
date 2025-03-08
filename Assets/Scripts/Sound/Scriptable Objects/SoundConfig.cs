using UnityEngine;

[CreateAssetMenu(fileName = "SoundConfig", menuName = "Scriptable Objects/Sound/SoundConfig")]
public class SoundConfig : ScriptableObject
{
    [SerializeField] private Sound[] sounds;

    public Sound[] Sounds => sounds;
}
