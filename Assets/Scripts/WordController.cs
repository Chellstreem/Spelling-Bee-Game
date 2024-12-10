using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordController : MonoBehaviour, IInitializable
{
    public static event System.Action<string> OnWordChanged;
    public static event System.Action<int, int> OnIndexChanged;

    private List<string> words = new List<string>();
    private HashSet<int> maskedIndices = new HashSet<int>();

    public static string CurrentWord;
    private string maskedWord;
    private int currentWordIndex;

    private const int MaskedLetterThreshold = 5;
    private const int MaskedLetterMinNum = 1;
    private const int MaskedLetterMaxNum = 2;

    public void Initialize()
    {        
        words = GameplayData.savedWords;

        currentWordIndex = 0;
        ShowCurrentWord();
        
        EventBus.OnLetterCollision += CheckLetter;
    }

    private void ShowCurrentWord()
    {
        if (currentWordIndex < words.Count)
        {
            CurrentWord = words[currentWordIndex];
            maskedWord = MaskWord(CurrentWord);
            UpdateDisplay();
        }
        else
        {            
            EventBus.InvokeVictory();
        }
    }    

    private string MaskWord(string word)
    {
        maskedIndices.Clear();

        char[] wordArray = word.ToCharArray();
        int hiddenLettersNumber = wordArray.Length > MaskedLetterThreshold ? MaskedLetterMaxNum : MaskedLetterMinNum;

        while (maskedIndices.Count < hiddenLettersNumber) 
        {
            int randomIndex = Random.Range(0, wordArray.Length);
            if (maskedIndices.Add(randomIndex))
            {
                wordArray[randomIndex] = '_';
            }
        }
        return new string(wordArray);
    }

    public void CheckLetter(string pickedLetter)
    {
        char letter = char.ToLower(pickedLetter[0]);
        char[] maskedArray = maskedWord.ToCharArray();
        bool letterRevealed = false;

        foreach (int index in maskedIndices.ToList())
        {
            if (CurrentWord[index] == letter)
            {
                maskedArray[index] = letter;
                letterRevealed = true;
                maskedIndices.Remove(index);                
            }
        }

        if (letterRevealed)
        {
            maskedWord = new string(maskedArray);
            UpdateDisplay();            

            if (maskedWord == CurrentWord)
            {
                currentWordIndex++;
                ShowCurrentWord();
                if (currentWordIndex < words.Count)
                    EventBus.InvokeWordCompleted();
            }
        }
        else
        {
            EventBus.InvokeLetterChecked(false);
            EventBus.InvokeLoss();
        }
    }

    private void UpdateDisplay()
    {        
        OnWordChanged?.Invoke(maskedWord);
        OnIndexChanged?.Invoke(currentWordIndex, words.Count);        
    }

    private void OnDestroy()
    {        
        EventBus.OnLetterCollision -= CheckLetter;
    }
}
