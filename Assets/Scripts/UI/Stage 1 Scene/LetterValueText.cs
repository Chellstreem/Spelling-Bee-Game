using TMPro;
using UnityEngine;
using InteractableObjects;

public class LetterValueText : MonoBehaviour
{
    private TextMeshProUGUI valueText;
    [SerializeField] private OrbLetter movingLetter;

    private void Awake()
    {
        valueText = GetComponent<TextMeshProUGUI>();        
    }

    private void OnEnable()
    {
        UpdateText(movingLetter.Value);
        movingLetter.OnLetterSet += UpdateText;
    }

    private void UpdateText(string value)
    {
        valueText.text = value.ToUpper();
    }

    private void OnDestroy()
    {
        movingLetter.OnLetterSet -= UpdateText;
    }
}
