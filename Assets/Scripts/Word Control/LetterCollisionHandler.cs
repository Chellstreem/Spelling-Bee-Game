using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LetterCollisionHandler : IEventSubscriber<OnLetterCollision>
{
    private IEventManager eventManager;
    private IWordMasker wordMasker;
    private ICurrentWordHandler currentWordHandler;

    public static string CurrentWord { get; private set; }
    public static string MaskedWord { get; private set; }

    public LetterCollisionHandler(IEventManager eventManager, IWordMasker wordMasker, ICurrentWordHandler currentWordHandler)
    {
        this.eventManager = eventManager;
        this.wordMasker = wordMasker;
        this.currentWordHandler = currentWordHandler;

        this.eventManager.Subscribe<OnLetterCollision>(this);
        OnNewCurrentWord();
    }

    public void OnEvent(OnLetterCollision eventData)
    {
        CheckLetter(eventData.Value, eventData.Position);
    }

    public void CheckLetter(string pickedLetter, Vector3 position)
    {
        char letter = char.ToLower(pickedLetter[0]);
        char[] maskedArray = MaskedWord.ToCharArray();
        HashSet<int> maskedIndices = wordMasker.GetMaskedIndices();

        foreach (int index in maskedIndices.ToList())
        {
            if (IsLetterValid(index, letter))
            {
                HandleValidLetter(maskedArray, maskedIndices, index, letter, position);
                if (MaskedWord == CurrentWord)
                {
                    HandleWordCompleted();
                }
                return;
            }
            else
            {
                HandleWrongLetter();
                return;
            }
        }
    }

    private void HandleValidLetter(char[] maskedArray, HashSet<int> maskedIndices, int index, char letter, Vector3 position)
    {
        maskedArray[index] = letter; // Вставляем пропушенную букву
        UpdateMaskedWord(maskedArray); // Обновляем MaskedWord
        maskedIndices.Remove(index);  // Удаляем индекс из maskedIndices

        wordMasker.UpdateMaskedIndices(maskedIndices);
        eventManager.Publish(new OnLetterChecked(true, position));
    }

    private void HandleWordCompleted()
    {
        currentWordHandler.MoveToNextWord();
        if (currentWordHandler.IsCurrentIndexValid())
        {
            OnNewCurrentWord();
            eventManager.Publish(new OnWordCompleted());

        }
        else
        {
            eventManager.Publish(new OnVictory());
        }
    }

    private void HandleWrongLetter()
    {
        eventManager.Publish(new OnDeath());
    }

    private void OnNewCurrentWord()
    {
        CurrentWord = currentWordHandler.GetCurrentWord();
        MaskedWord = wordMasker.MaskWord(CurrentWord);
    }

    private bool IsLetterValid(int index, char letter) => CurrentWord[index] == letter;

    private void UpdateMaskedWord(char[] maskedArray) => MaskedWord = new string(maskedArray);
}
