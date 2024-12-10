using UnityEngine;
using TMPro;
using System.Text;
using Unity.VisualScripting;

public class RandomLetter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI valueText;    

    public string Value { get; private set; }

    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
    private const int ExtraWordAmount = 7; // Дополнительное количество букв для небольшого усложнения игры
    private string letters;

    void OnEnable()
    {
        SetRandomLetter();
    }

    private void SetRandomLetter()
    {        
        letters = GenerateExtraLetters(WordController.CurrentWord, ExtraWordAmount);
        char randomLetter = letters[Random.Range(0, letters.Length)];
        valueText.text = randomLetter.ToString().ToUpper();

        Value = randomLetter.ToString().ToLower();
    }

    private string GenerateExtraLetters(string baseWord, int extraAmount)
    {
        StringBuilder sb = new StringBuilder(baseWord);
        while (sb.Length < baseWord.Length + extraAmount)
        {
            sb.Append(Alphabet[Random.Range(0, Alphabet.Length)]);
        }
        return sb.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventBus.InvokeLetterCollision(Value);
            EventBus.InvokeReturnedToPool(gameObject);
        }
    }
}
