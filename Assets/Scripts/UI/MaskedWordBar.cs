using TMPro;
using UnityEngine;
using Zenject;

public class MaskedWordBar : MonoBehaviour, IEventSubscriber<OnVictory>, IEventSubscriber<OnLetterChecked>
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
        UpdateText();
        eventManager.Subscribe<OnLetterChecked>(this);
        eventManager.Subscribe<OnVictory>(this);
    }

    public void OnEvent(OnVictory eventData)
    {
        text.text = VictoryMessage;
    }

    public void OnEvent(OnLetterChecked eventData)
    {
        UpdateText();
    }

    private void UpdateText() => text.text = WordManager.MaskedWord.ToUpper();

    private void OnDestroy()
    {
        eventManager.Unsubscribe<OnLetterChecked>(this);
        eventManager.Unsubscribe<OnVictory>(this);
    }
}
