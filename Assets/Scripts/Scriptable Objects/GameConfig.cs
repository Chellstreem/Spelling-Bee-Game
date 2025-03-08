using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Scriptable Objects/GameConfig")]
public class GameConfig : ScriptableObject
{
    [Header("General Config")]    
    [SerializeField] private float speed = 20f;    
    public float Speed => speed;    

    //

    [Header("Movable Object Config")]    
    [SerializeField] private Vector3 backgroundPosition;
    [SerializeField] private float thresholdZ;    
    public Vector3 BackgroundPosition => backgroundPosition;
    public float ThresholdZ => thresholdZ;

    //

    [Header("Random Letter Config")]
    [SerializeField] private int extraLettersCount = 7;
    [SerializeField] private string alphabetLetters = "abcdefghijklmnopqrstuvwxyz";
    public int ExtraLettersCount => extraLettersCount;   
    public string AlphabetLetters => alphabetLetters;    

    //

    [Header("Missile Config")]
    [SerializeField] private float missileSpeed = 30f;
    [SerializeField] private float missileSpawnFrequency = 0.5f;
    [SerializeField] private float delayBeforeLaunching = 2f;
    [SerializeField] private float missileSateDuration = 3.5f;
    public float MissileSpeed => missileSpeed;
    public float MissileSpawnFrequency => missileSpawnFrequency;
    public float DelayBeforeLaunching => delayBeforeLaunching;
    public float MissileSateDuration => missileSateDuration;
}
