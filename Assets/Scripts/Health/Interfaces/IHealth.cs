using System;

public interface IHealth
{
    public float LivesRemaining { get; }
    public float LifeRatio { get; }
    public event Action<HealthChangeType> OnHealthChanged;
}
