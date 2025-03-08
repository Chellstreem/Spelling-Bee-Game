using UnityEngine;

[CreateAssetMenu(fileName = "WordControlConfig", menuName = "Scriptable Objects/WordControlConfig")]
public class WordControlConfig : ScriptableObject
{
    [SerializeField] private int maskedLetterThreshold = 5; // Количество букв в слове, котором будет скрыто максимальное колисетво скрытых букв
    [SerializeField] private int maskedLetterMinNum = 1; // Минимальное количество скрытых букв
    [SerializeField] private int maskedLetterMaxNum = 2; // Максимальное количество скрытых букв

    public int MaskedLetterThreshold => maskedLetterThreshold;
    public int MaskedLetterMinNum => maskedLetterMinNum;
    public int MaskedLetterMaxNum => maskedLetterMaxNum;
}
