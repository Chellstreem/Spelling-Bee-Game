using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class CurrentIndexBar : MonoBehaviour, IEventSubscriber<OnWordCompleted>, IEventSubscriber<OnVictory>
{
    [SerializeField] private TextMeshProUGUI text;
    private IEventManager eventManager;
    private IIndexGetter indexGetter;

    private int wordCount;

    [Inject]
    public void Construct(IEventManager eventManager, IIndexGetter indexGetter)
    {
        this.eventManager = eventManager;
        this.indexGetter = indexGetter;
    }

    private void Start()
    {
        wordCount = indexGetter.GetTotalWords();
        UpdateIndex();

        eventManager.Subscribe<OnWordCompleted>(this);
    }

    public void OnEvent(OnWordCompleted eventData)
    {
        UpdateIndex();
    }

    public void OnEvent(OnVictory eventData)
    {
        text.text = $"{wordCount} / {wordCount}";
    }

    private void UpdateIndex()
    {
        text.text = $"{indexGetter.GetCurrentWordIndex().ToString()} / {wordCount}";
    }

    private void OnDestroy()
    {
        eventManager.Unsubscribe<OnWordCompleted>(this);
    }
}
