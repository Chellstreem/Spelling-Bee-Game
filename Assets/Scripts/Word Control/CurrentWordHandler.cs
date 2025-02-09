using System.Collections.Generic;
using UnityEngine;

public class CurrentWordHandler : ICurrentWordHandler, IIndexGetter
{
    private List<string> words;
    private int currentWordIndex;

    public CurrentWordHandler()
    {
        words = GameplayData.SavedWords;
        currentWordIndex = 0;
    }

    public string GetCurrentWord() => words[currentWordIndex];

    public int GetCurrentWordIndex() => currentWordIndex;

    public void MoveToNextWord() => currentWordIndex++;       

    public bool IsCurrentIndexValid() => currentWordIndex < words.Count;   

    public int GetTotalWords() => words.Count;    
}
