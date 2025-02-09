using UnityEngine;
using Zenject;

public class ActivatorUI : MonoBehaviour, IEventSubscriber<OnVictory>, IEventSubscriber<OnDeath>, IEventSubscriber<OnCountdownEnter>, IEventSubscriber<OnCountdownExit>
{
    private IEventManager eventManager;

    [SerializeField] public GameObject gameOverMenu;       
    [SerializeField] public GameObject countdownBar;       

    [Inject]
    public void Construct(IEventManager eventManager)
    {
        this.eventManager = eventManager;
        SubscribeToEvents();        
    }
    
    private void SubscribeToEvents()
    {
        eventManager.Subscribe<OnVictory>(this);
        eventManager.Subscribe<OnDeath>(this);
        eventManager.Subscribe<OnCountdownEnter>(this);
        eventManager.Subscribe<OnCountdownExit>(this);
    }
    
    public void OnEvent(OnVictory eventData) => ShowGameOverMenu();

    public void OnEvent(OnDeath eventData) => ShowGameOverMenu(); 
    
    public void OnEvent(OnCountdownEnter eventData) => ActivateCountdownBar(); 
    
    public void OnEvent(OnCountdownExit eventData) => DeactivateCountdownBar();          

    private void ShowGameOverMenu() => gameOverMenu.SetActive(true);

    private void ActivateCountdownBar()
    {
        countdownBar.SetActive(true);        
    }    

    private void DeactivateCountdownBar() => countdownBar.SetActive(false);

    private void UnsubscribeFromEvents()
    {
        eventManager.Unsubscribe<OnVictory>(this);
        eventManager.Unsubscribe<OnDeath>(this);
        eventManager.Unsubscribe<OnCountdownEnter>(this);
        eventManager.Unsubscribe<OnCountdownExit>(this);
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }
}


