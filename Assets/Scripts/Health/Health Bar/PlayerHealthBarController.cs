using UnityEngine;
using Zenject;

public class PlayerHealthBarController : IInitializable, IEventSubscriber<OnMovingStateEnter>, IEventSubscriber<OnMovingStateExit>
{   
    private readonly IEventManager eventManager;
    private readonly IScaler scaler;
    private readonly GameObject healthBarObj;
    private readonly Transform healthBarTransform;
    private readonly Transform playerTransform; // Шкала здоровья будет дочерним объектом этого объекта
    private readonly Vector3 healthBarLocalPosition;

    public PlayerHealthBarController(
        IEventManager eventManager, IScaler scaler,
        [Inject(Id = InstantiatedObjectType.HealthBar)] Transform healthBarTransform,
        [Inject(Id = InstantiatedObjectType.Player)] Transform playerTransform,
        PlayerHealthConfig config)
    {
        this.eventManager = eventManager;
        this.scaler = scaler;
        this.healthBarTransform = healthBarTransform;
        healthBarObj = healthBarTransform.gameObject;
        this.playerTransform = playerTransform;
        healthBarLocalPosition = config.HealthBarLocalPosition;
    }

    public void Initialize()
    {
        SetParent();
        ToggleActivation(false);
        SubsribeToEvents();
    }

    public void OnEvent(OnMovingStateEnter eventData) => scaler.ShowWithScale(healthBarTransform);

    public void OnEvent(OnMovingStateExit eventData) => scaler.HideWithScale(healthBarTransform);

    private void ToggleActivation(bool isActive) => healthBarObj.SetActive(isActive);   

    private void SetParent()
    {
        healthBarTransform.SetParent(playerTransform);
        healthBarTransform.localPosition = healthBarLocalPosition;
    }

    private void SubsribeToEvents()
    {
        eventManager.Subscribe<OnMovingStateEnter>(this);
        eventManager.Subscribe<OnMovingStateExit>(this);
    }
}
