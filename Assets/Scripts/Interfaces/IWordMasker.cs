using System.Collections.Generic;

public interface IWordMasker
{
    public string MaskWord(string word);

    public HashSet<int> GetMaskedIndices();

    public void UpdateMaskedIndices(HashSet<int> hashSet);
}
