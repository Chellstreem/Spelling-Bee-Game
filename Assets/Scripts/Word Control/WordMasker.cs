using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordMasker : IWordMasker
{
    private readonly int maskedLetterThreshold;
    private readonly int maskedLetterMinNum;
    private readonly int maskedLetterMaxNum;

    public WordMasker(WordControlConfig config)
    {
        maskedLetterThreshold = config.MaskedLetterThreshold;
        maskedLetterMinNum = config.MaskedLetterMinNum;
        maskedLetterMaxNum = config.MaskedLetterMaxNum;
    }

    public MaskedWordData MaskWord(string word)
    {
        int lettersToMask = word.Length > maskedLetterThreshold ? maskedLetterMaxNum : maskedLetterMinNum;        

        char[] maskedWordArray = word.ToCharArray();
        Dictionary<string, int> maskedIndexes = new Dictionary<string, int>();

        while (maskedIndexes.Count < lettersToMask)
        {
            int randomIndex = UnityEngine.Random.Range(0, maskedWordArray.Length);
            string hiddenLetter = maskedWordArray[randomIndex].ToString();
            if (!maskedIndexes.ContainsKey(hiddenLetter))
            {
                maskedIndexes.Add(hiddenLetter, randomIndex);
                maskedWordArray[randomIndex] = '_';
            }
        }

        string maskedWord = new string(maskedWordArray);        
        return new MaskedWordData(maskedWord, maskedIndexes);
    }
}
