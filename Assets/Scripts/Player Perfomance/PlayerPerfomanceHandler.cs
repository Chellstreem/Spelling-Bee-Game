using System;

public class PlayerPerfomanceHandler : IDisposable, IEventSubscriber<OnAllWordsCompleted>
{
    private readonly IEventManager eventManager;
    private readonly IHealth playerHealth;

    public PlayerPerfomanceHandler(IEventManager eventManager, IHealth playerHealth)
    {
        this.eventManager = eventManager;
        this.playerHealth = playerHealth;

        playerHealth.OnHealthChanged += OnLifeChanged;
        eventManager.Subscribe<OnAllWordsCompleted>(this);
    }

    private void OnLifeChanged(HealthChangeType changeType)
    {
        if (playerHealth.LivesRemaining <= 0)
            eventManager.Publish(new OnDeath());        
    }

    public void OnEvent(OnAllWordsCompleted eventData)
    {
        eventManager.Publish(new OnVictory());
    }

    public void Dispose()
    {
        playerHealth.OnHealthChanged -= OnLifeChanged;
        eventManager.Unsubscribe<OnAllWordsCompleted>(this);
    }
}
