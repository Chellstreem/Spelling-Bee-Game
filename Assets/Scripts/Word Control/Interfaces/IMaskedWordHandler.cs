using System.Collections.Generic;

public interface IMaskedWordHandler
{
    public string GetMaskedWord();
    public void SetCurrentMaskedWord(string word);
    public int GetHiddenIndex(string letter);
    public void RevealHiddenLetter(string letter);    
}
