using TMPro;
using UnityEngine;
using Zenject;

public class MaskedWordBar : MonoBehaviour, IEventSubscriber<OnVictory>, IEventSubscriber<OnLetterChecked>, IEventSubscriber<OnWordCompleted>
{
    [SerializeField] private TextMeshProUGUI text;
    private IEventManager eventManager;
    private const string VictoryMessage = "YOU DID IT!";

    [Inject]
    public void Construct(IEventManager eventManager)
    {
        this.eventManager = eventManager;        
    }

    private void Start()
    {
        UpdateMaskedWord();
        SubscribeToEvents();
    }

    public void OnEvent(OnVictory eventData)
    {
        text.text = VictoryMessage;
    }

    public void OnEvent(OnLetterChecked eventData)
    {
        UpdateMaskedWord();
    }

    public void OnEvent(OnWordCompleted eventData)
    {
        UpdateMaskedWord();
    }

    private void UpdateMaskedWord() => text.text = LetterCollisionHandler.MaskedWord.ToUpper();

    private void SubscribeToEvents()
    {
        eventManager.Subscribe<OnLetterChecked>(this);
        eventManager.Subscribe<OnVictory>(this);
        eventManager.Subscribe<OnWordCompleted>(this);
    }

    private void UnsubscribeFromEvents()
    {
        eventManager.Unsubscribe<OnLetterChecked>(this);
        eventManager.Unsubscribe<OnVictory>(this);
        eventManager.Unsubscribe<OnWordCompleted>(this);
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }
}
