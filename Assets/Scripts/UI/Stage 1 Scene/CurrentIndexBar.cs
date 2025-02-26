using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class CurrentIndexBar : MonoBehaviour, IEventSubscriber<OnWordCompleted>, IEventSubscriber<OnVictoryStateEnter>
{
    private IEventManager eventManager;
    private ICurrentIndexGetter indexGetter;

    private TextMeshProUGUI text;
    private int wordCount;

    [Inject]
    public void Construct(IEventManager eventManager, ICurrentIndexGetter indexGetter)
    {
        this.eventManager = eventManager;
        this.indexGetter = indexGetter;
    }

    private void Awake()
    {
        wordCount = indexGetter.GetTotalWords();

        text = GetComponent<TextMeshProUGUI>();
        UpdateIndex();

        eventManager.Subscribe<OnWordCompleted>(this);
        eventManager.Subscribe<OnVictoryStateEnter>(this);
    }

    public void OnEvent(OnWordCompleted eventData)
    {
        UpdateIndex();
    }

    public void OnEvent(OnVictoryStateEnter eventData)
    {
        text.text = $"{wordCount} / {wordCount}";
    }

    private void UpdateIndex()
    {
        text.text = $"{indexGetter.GetCurrentWordIndex()} / {wordCount}";
    }

    private void OnDestroy()
    {
        eventManager.Unsubscribe<OnWordCompleted>(this);
        eventManager.Unsubscribe<OnVictoryStateEnter>(this);
    }
}
