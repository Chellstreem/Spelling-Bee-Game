using UnityEngine;

[CreateAssetMenu(fileName = "SoundCollection", menuName = "Scriptable Objects/SoundCollection")]
public class SoundCollection : ScriptableObject
{
    [SerializeField] private Sound[] sounds;

    public Sound[] Sounds => sounds;
}
