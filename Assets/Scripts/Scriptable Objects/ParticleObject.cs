using UnityEngine;

[CreateAssetMenu(fileName = "ParticleObject", menuName = "Scriptable Objects/ParticleObject")]
public class ParticleObject : ScriptableObject
{
    public enum ParticleType
    {
        ArcadeSpark,
        BasicSpark,
        BirthdaySpark,
        BirthdayConfetti,
        ConfettiRain,
        SoulEscape
    }

    [SerializeField] private ParticleType type;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int amount;

    public ParticleType Type => type;
    public GameObject Prefab => prefab;
    public int Amount => amount;
}
    
