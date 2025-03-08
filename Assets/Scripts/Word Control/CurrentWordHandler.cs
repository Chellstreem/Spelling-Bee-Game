using System;
using System.Collections.Generic;

public class CurrentWordHandler : ICurrentWordHandler, ICurrentIndexGetter, ICurrentWordGetter
{
    private List<string> words;
    private int currentWordIndex;

    public event Action OnNewCurrentWord;

    public CurrentWordHandler()
    {
        words = GameplayData.GameplayData.SavedWords;
        currentWordIndex = 0;
    }

    public string GetCurrentWord() => words[currentWordIndex];

    public int GetCurrentWordIndex() => currentWordIndex;

    public void MoveToNextWord()
    { 
        currentWordIndex++;
        OnNewCurrentWord?.Invoke();
    }

    public bool IsCurrentIndexLast() => currentWordIndex == words.Count - 1;   

    public int GetTotalWords() => words.Count;    
}
