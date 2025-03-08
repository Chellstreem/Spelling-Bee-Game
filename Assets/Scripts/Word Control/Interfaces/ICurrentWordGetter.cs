using System;

public interface ICurrentWordGetter
{
    public string GetCurrentWord();

    public event Action OnNewCurrentWord;
}
