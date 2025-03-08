using UnityEngine;

[CreateAssetMenu(fileName = "GameStateConfig", menuName = "Scriptable Objects/GameStateConfig")]
public class GameStateConfig : ScriptableObject
{
    [Header("Countdown Config")]
    [SerializeField] private int count = 3;
    [SerializeField] private int fontSize = 320;
    [SerializeField] private int fontSizeDecrement = 45; // Насколько уменьшается размер шрифта при каждом тике    
    [SerializeField] private int finalFontSize = 350; // Размер шрифта для надписи Go!

    public int Count => count;
    public int FontSize => fontSize;
    public int FontSizeDecrement => fontSizeDecrement;
    public int FinalFontSize => finalFontSize;

    [Header("Safe Substate")]
    [SerializeField] private float safeSubstateDuration = 1;

    public float SafeSubstateDuration => safeSubstateDuration;
}
