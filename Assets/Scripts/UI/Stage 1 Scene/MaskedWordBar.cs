using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class MaskedWordBar : MonoBehaviour, IEventSubscriber<OnVictoryStateEnter>, IEventSubscriber<OnLetterChecked>
{
    private IEventManager eventManager;
    private IMaskedWordGetter maskedWordGetter;

    private readonly string victoryMessage = "YOU DID IT!";
    private readonly float delayBeforeVictoryMessage = 1f;

    private TextMeshProUGUI text;

    [Inject]
    public void Construct(IEventManager eventManager, IMaskedWordGetter maskedWordGetter)
    {
        this.eventManager = eventManager;
        this.maskedWordGetter = maskedWordGetter;
    }

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

        UpdateText();
        SubscribeToEvents();
    }

    public void OnEvent(OnVictoryStateEnter eventData)
    {
        StartCoroutine(UpdateVictoryMessageWithDelay(delayBeforeVictoryMessage));        
    }

    public void OnEvent(OnLetterChecked eventData)
    {
        if (eventData.IsCorrect)
            UpdateText();
    }

    private void UpdateText()
    {
        text.text = maskedWordGetter.GetMaskedWord().ToUpper();        
    }        

    private void SubscribeToEvents()
    {
        eventManager.Subscribe<OnLetterChecked>(this);
        eventManager.Subscribe<OnVictoryStateEnter>(this);
    }

    private void UnsubscribeFromEvents()
    {        
        eventManager.Unsubscribe<OnLetterChecked>(this);
        eventManager.Unsubscribe<OnVictoryStateEnter>(this);
    }

    private IEnumerator UpdateVictoryMessageWithDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        text.text = victoryMessage;
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }
}