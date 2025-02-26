using TMPro;
using UnityEngine;
using Zenject;

public class CountdownBar : MonoBehaviour, IEventSubscriber<OnCountdownTick>
{
    private TextMeshProUGUI text;    
    private IEventManager eventManager;

    [Inject]
    public void Construct(IEventManager eventManager)
    {        
        this.eventManager = eventManager;
    }

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();        
    }

    private void OnEnable()
    {
        eventManager.Subscribe<OnCountdownTick>(this);      
    }

    public void OnEvent(OnCountdownTick eventData)
    {       
        int count  = eventData.Count;
        int fontSize = eventData.FontSize;
        int finalFontSize = eventData.FinalFontSize;
        UpdateCountdown(count, fontSize, finalFontSize);
    }

    public void UpdateCountdown(int count, int fontSize, int goFontSize)
    {        
        if (count == 0)
        {

            text.fontSize = goFontSize;
            text.text = "GO!";            
        }
        else
        {
            text.fontSize = fontSize;
            text.text = count.ToString();            
        }
    }

    private void OnDestroy() => eventManager.Unsubscribe<OnCountdownTick>(this);

    private void OnDisable() => eventManager.Unsubscribe<OnCountdownTick>(this);
}
