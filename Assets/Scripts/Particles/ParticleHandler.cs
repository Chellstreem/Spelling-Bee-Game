using System;
using System.Collections;
using UnityEngine;

public class ParticleHandler : IEventSubscriber<OnLetterChecked>, IEventSubscriber<OnWordCompleted>, IEventSubscriber<OnVictory>,
    IEventSubscriber<OnDeath>, IEventSubscriber<OnMissileCollision>
{
    private readonly IEventManager eventManager;
    private readonly IParticlePlayer player;
    private readonly ICoroutineRunner coroutineRunner;
    private Vector3 playerPosition;

    private readonly float confettiRainOffsetY = 14f;
    private readonly float delayForSoulEscape = 0.8f;

    public ParticleHandler(IEventManager eventManager, IParticlePlayer player, ICoroutineRunnerHolder runnerHolder, GameConfig gameConfig)
    {
        this.eventManager = eventManager;
        this.player = player;
        coroutineRunner = runnerHolder.CoroutineRunner;
        playerPosition = gameConfig.PlayerPosition;

        SubscribeToEvents();
    }

    public void OnEvent(OnLetterChecked eventData)
    {
        if (eventData.IsCorrect)
            player.PlayParticle(ParticleType.ArcadeSpark, eventData.Position);
    }

    public void OnEvent(OnWordCompleted eventData)
    {
        player.PlayParticle(ParticleType.BirthdayConfetti, playerPosition);
    }

    public void OnEvent(OnVictory eventData)
    {
        float x = playerPosition.x;
        float y = playerPosition.y + confettiRainOffsetY;
        float z = playerPosition.z;
        player.PlayParticle(ParticleType.ConfettiRain, new Vector3(x, y, z));
    }

    public void OnEvent(OnDeath eventData)
    {
        coroutineRunner.StartCor(RunWithDelayCoroutine(player.PlayParticle, ParticleType.SoulEscape, playerPosition, delayForSoulEscape));
    }

    public void OnEvent(OnMissileCollision eventData)
    {
        player.PlayParticle(ParticleType.MissileExplosion, eventData.Position);
    }

    private IEnumerator RunWithDelayCoroutine<T1, T2>(Action<T1, T2> method, T1 param1, T2 param2, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        method?.Invoke(param1, param2);
    }

    private void SubscribeToEvents()
    {
        eventManager.Subscribe<OnLetterChecked>(this);
        eventManager.Subscribe<OnWordCompleted>(this);
        eventManager.Subscribe<OnVictory>(this);
        eventManager.Subscribe<OnDeath>(this);
        eventManager.Subscribe<OnMissileCollision>(this);
    }

    private void UnsubscribeFromEvents()
    {
        eventManager.Unsubscribe<OnLetterChecked>(this);
        eventManager.Unsubscribe<OnWordCompleted>(this);
        eventManager.Unsubscribe<OnVictory>(this);
        eventManager.Unsubscribe<OnDeath>(this);
        eventManager.Unsubscribe<OnMissileCollision>(this);
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }
}
