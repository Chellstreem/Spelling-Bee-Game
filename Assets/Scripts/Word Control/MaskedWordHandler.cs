using System;
using System.Collections.Generic;
using System.Diagnostics;

public class MaskedWordHandler : IWordMasker
{
    private readonly int maskedLetterThreshold;
    private readonly int maskedLetterMinNum;
    private readonly int maskedLetterMaxNum;

    private HashSet<int> maskedIndices;

    public MaskedWordHandler(GameConfig gameConfig)
    {
        maskedLetterThreshold = gameConfig.MaskedLetterThreshold;
        maskedLetterMinNum = gameConfig.MaskedLetterMinNum;
        maskedLetterMaxNum = gameConfig.MaskedLetterMaxNum;        
    }

    public string MaskWord(string word)
    {        
        int hiddenLettersNumber = word.Length > maskedLetterThreshold ? maskedLetterMaxNum : maskedLetterMinNum;
        hiddenLettersNumber = Math.Min(hiddenLettersNumber, word.Length); 
        
        char[] wordArray = word.ToCharArray();
        maskedIndices = new HashSet<int>();

        while (maskedIndices.Count < hiddenLettersNumber)
        {
            int randomIndex = UnityEngine.Random.Range(0, wordArray.Length);
            if (maskedIndices.Add(randomIndex))
            {
                wordArray[randomIndex] = '_';
            }
        }
        return new string(wordArray);
    }

    public HashSet<int> GetMaskedIndices()
    {
        return maskedIndices;
    }    

    public void UpdateMaskedIndices(HashSet<int> hashSet)
    {
        maskedIndices = hashSet;
    }
}
