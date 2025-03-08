using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskedWordHandler : IMaskedWordGetter, IMaskedWordHandler, IHiddenIndexGetter
{
    private readonly IWordMasker wordMasker;    

    private MaskedWordData currentMaskedWord;

    public MaskedWordHandler(IWordMasker wordMasker)
    {
        this.wordMasker = wordMasker;        
    }

    public void SetCurrentMaskedWord(string word)
    {        
        currentMaskedWord = wordMasker.MaskWord(word);
    }

    public string GetMaskedWord() => currentMaskedWord?.MaskedWord;

    public int GetHiddenIndex(string letter) => currentMaskedWord.HiddenIndices.TryGetValue(letter, out int index) ? index : -1;

    public void RevealHiddenLetter(string letter)
    {
        if (currentMaskedWord.HiddenIndices.ContainsKey(letter))
        {
            int index = GetHiddenIndex(letter);
            currentMaskedWord.HiddenIndices.Remove(letter);
            UpdateMaskedWordText(letter, index);
        }
    }

    private void UpdateMaskedWordText(string letter, int index)
    {
        char[] maskedWordArray = currentMaskedWord.MaskedWord.ToCharArray();        
        maskedWordArray[index] = letter[0];
        currentMaskedWord.MaskedWord = new string(maskedWordArray);
    }
}
