using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongLetterHandler : IEventSubscriber<OnLetterChecked>
{
    private readonly IEventManager eventManager;
    private readonly IDamageDealer damageDealer;

    private readonly int damage = 1;

    public WrongLetterHandler(IEventManager eventManager, IDamageDealer damageDealer, PlayerPerfomanceConfig config)
    {
        this.eventManager = eventManager;
        this.damageDealer = damageDealer;
        damage = config.WrongLetterDamage;

        this.eventManager.Subscribe<OnLetterChecked>(this);
    }

    public void OnEvent(OnLetterChecked eventData)
    {
        if (!eventData.IsCorrect) 
        {
            damageDealer.DamagePlayer(damage);
        }
    }
}
