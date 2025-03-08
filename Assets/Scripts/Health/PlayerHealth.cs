using System;
using UnityEngine;

public class PlayerHealth : IHealth, IDamageDealer, ILiveRestorer
{
    private readonly int maxLives;
    private readonly int livesOnStart;
    private int livesRemaining;
   
    public float LivesRemaining => livesRemaining;
    public float LifeRatio => (float)livesRemaining / maxLives;

    public event Action<HealthChangeType> OnHealthChanged;

    public PlayerHealth(PlayerHealthConfig config)
    {
        maxLives = config.MaxLives;
        livesOnStart = Mathf.Min(config.LivesOnStart, maxLives);
        livesRemaining = livesOnStart;        
    }

    public void DamagePlayer(int amount)
    {
        livesRemaining = Mathf.Max(0, livesRemaining - amount);
        OnHealthChanged?.Invoke(HealthChangeType.Damaged);        
    }

    public void RestorePlayerLives(int amount)
    {
        livesRemaining = Mathf.Min(maxLives, livesRemaining + amount);
        OnHealthChanged?.Invoke(HealthChangeType.Restored);
    }
}
