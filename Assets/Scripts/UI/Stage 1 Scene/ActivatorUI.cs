using UnityEngine;
using Zenject;

public class ActivatorUI : MonoBehaviour, IEventSubscriber<OnVictory>, IEventSubscriber<OnBeingDamaged>,
    IEventSubscriber<OnCountdownStateEnter>, IEventSubscriber<OnCountdownStateExit>, IEventSubscriber<OnMissileStateEnter>,
    IEventSubscriber<OnMissileStateExit>
{
    private IEventManager eventManager;

    [SerializeField] public GameObject gameOverMenu;       
    [SerializeField] public GameObject countdownBar;       
    [SerializeField] public GameObject missileAlertBar;       

    [Inject]
    public void Construct(IEventManager eventManager)
    {
        this.eventManager = eventManager;
        SubscribeToEvents();        
    }
    
    private void SubscribeToEvents()
    {
        eventManager.Subscribe<OnVictory>(this);
        eventManager.Subscribe<OnBeingDamaged>(this);
        eventManager.Subscribe<OnCountdownStateEnter>(this);
        eventManager.Subscribe<OnCountdownStateExit>(this);
        eventManager.Subscribe<OnMissileStateEnter>(this);
        eventManager.Subscribe<OnMissileStateExit>(this);
    }
    
    public void OnEvent(OnVictory eventData) => ShowGameOverMenu();

    public void OnEvent(OnBeingDamaged eventData) => ShowGameOverMenu(); 
    
    public void OnEvent(OnCountdownStateEnter eventData) => ToggleCountdownBarActivation(true); 
    
    public void OnEvent(OnCountdownStateExit eventData) => ToggleCountdownBarActivation(false);

    public void OnEvent(OnMissileStateEnter eventData) => ToggleMissileAlertBarActivation(true);

    public void OnEvent(OnMissileStateExit eventData) => ToggleMissileAlertBarActivation(false);

    private void ShowGameOverMenu() => gameOverMenu.SetActive(true);

    private void ToggleCountdownBarActivation(bool isActivated) => countdownBar.SetActive(isActivated);    
    
    private void ToggleMissileAlertBarActivation(bool isActivated) => missileAlertBar.SetActive(isActivated);     

    private void UnsubscribeFromEvents()
    {
        eventManager.Unsubscribe<OnVictory>(this); 
        eventManager.Unsubscribe<OnBeingDamaged>(this);
        eventManager.Unsubscribe<OnCountdownStateEnter>(this);
        eventManager.Unsubscribe<OnCountdownStateExit>(this);
        eventManager.Unsubscribe<OnMissileStateEnter>(this);
        eventManager.Unsubscribe<OnMissileStateExit>(this);
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }
}


