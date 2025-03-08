using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Zenject;

public class LetterGenerator : ILetterProvider, IInitializable, IDisposable
{
    private readonly ICurrentWordGetter currentWordGetter;
    private readonly string alphabetLetters;
    private readonly int extraLettersCount; // Дополнительное количество букв для небольшого усложнения игры

    private string currentAvailableLetters;

    public LetterGenerator(ICurrentWordGetter currentWordGetter, GameConfig config)
    {
        this.currentWordGetter = currentWordGetter;
        alphabetLetters = config.AlphabetLetters;
        extraLettersCount = config.ExtraLettersCount;

        UpdateAvailableLetters();
    }
    
    public void Initialize()
    {        
        currentWordGetter.OnNewCurrentWord += UpdateAvailableLetters;
    }

    public string GetRandomLetter()
    {
        return currentAvailableLetters[UnityEngine.Random.Range(0, currentAvailableLetters.Length)].ToString();
    }

    public void Dispose() => currentWordGetter.OnNewCurrentWord -= UpdateAvailableLetters;   

    private void UpdateAvailableLetters()
    {
        currentAvailableLetters = GenerateExtraLetters(currentWordGetter.GetCurrentWord(), extraLettersCount);        
    }

    private string GenerateExtraLetters(string baseWord, int extraAmount)
    {
        if (extraAmount == 0)
            return baseWord;

        StringBuilder sb = new StringBuilder(baseWord);
        HashSet<char> usedLetters = new HashSet<char>(baseWord);
        while (sb.Length < baseWord.Length + extraAmount)
        {
            char newLetter = alphabetLetters[UnityEngine.Random.Range(0, alphabetLetters.Length)];

            if (!usedLetters.Contains(newLetter)) // Проверяем, не была ли добавлена эта буква ранее
            {
                sb.Append(newLetter);
                usedLetters.Add(newLetter);
            }            
        }
        return sb.ToString();
    }
}
