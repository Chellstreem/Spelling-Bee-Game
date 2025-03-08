using Zenject;
using System;

public class CorrectLetterHandler : IEventSubscriber<OnLetterChecked>
{
    private readonly IEventManager eventManager;
    private readonly ICurrentWordHandler currentWord;
    private readonly IMaskedWordHandler maskedWord;    

    public CorrectLetterHandler(IEventManager eventManager, ICurrentWordHandler currentWordHandler, IMaskedWordHandler maskedWordHandler)
    {
        this.eventManager = eventManager;
        currentWord = currentWordHandler;
        maskedWord = maskedWordHandler;
        
        this.eventManager.Subscribe<OnLetterChecked>(this);
    }

    [Inject]
    public void Initialize()
    {
        UpdateMaskedWord(currentWord.GetCurrentWord());
    }

    public void OnEvent(OnLetterChecked eventData)
    {
        if (!eventData.IsCorrect) return;

        maskedWord.RevealHiddenLetter(eventData.Letter);
        if (maskedWord.GetMaskedWord() != currentWord.GetCurrentWord()) return;
        if (currentWord.IsCurrentIndexLast())
        {
            eventManager.Publish(new OnAllWordsCompleted());
        }
        else
        {
            currentWord.MoveToNextWord();
            UpdateMaskedWord(currentWord.GetCurrentWord());
            eventManager.Publish(new OnWordCompleted());
        }        
    }

    private void UpdateMaskedWord(string word)
    {
        maskedWord.SetCurrentMaskedWord(word);
    }
}
