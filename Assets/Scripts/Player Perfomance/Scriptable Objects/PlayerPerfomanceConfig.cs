using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPerfomanceConfig", menuName = "Scriptable Objects/PlayerPerfomanceConfig")]
public class PlayerPerfomanceConfig : ScriptableObject
{
    [SerializeField] private int wrongLetterDamage;

    public int WrongLetterDamage => wrongLetterDamage;
}
