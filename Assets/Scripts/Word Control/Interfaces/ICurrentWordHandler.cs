public interface ICurrentWordHandler
{
    public string GetCurrentWord();

    public void MoveToNextWord();

    public bool IsCurrentIndexLast();
}
