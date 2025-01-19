using System.Collections;
using UnityEngine;
using System;

namespace Particle
{
    public class Particles : IEventSubscriber<OnLetterChecked>, IEventSubscriber<OnWordCompleted>, IEventSubscriber<OnVictory>, IEventSubscriber<OnDeath>, IParticlePlayer
    {
        private IParticlePool particlePool;
        private IEventManager eventManager;
        private ICoroutineRunner coroutineRunner;
        private Vector3 playerPosition;

        private float confettiRainOffsetY = 14f;
        private float delayForSoulEscape = 0.8f;

        public Particles(IParticlePool particlePool, IEventManager eventManager, ICoroutineRunnerHolder runnerHolder, GameConfig gameConfig)
        {
            this.particlePool = particlePool;
            this.eventManager = eventManager;
            coroutineRunner = runnerHolder.CoroutineRunner;
            playerPosition = gameConfig.PlayerPosition;

            eventManager.Subscribe<OnLetterChecked>(this);
            eventManager.Subscribe<OnWordCompleted>(this);
            eventManager.Subscribe<OnVictory>(this);
            eventManager.Subscribe<OnDeath>(this);
        }

        public void OnEvent(OnLetterChecked eventData)
        {
            if (eventData.IsCorrect)
                PlayParticle(ParticleType.ArcadeSpark, eventData.Position);
        }

        public void OnEvent(OnWordCompleted eventData)
        {
            PlayParticle(ParticleType.BirthdayConfetti, playerPosition);
        }

        public void OnEvent(OnVictory eventData)
        {
            float x = playerPosition.x;
            float y = playerPosition.y + confettiRainOffsetY;
            float z = playerPosition.z;
            PlayParticle(ParticleType.ConfettiRain, new Vector3(x, y, z));
        }

        public void OnEvent(OnDeath eventData)
        {
            coroutineRunner.StartCor(RunWithDelayCoroutine(
                PlayParticle, ParticleType.SoulEscape, playerPosition, delayForSoulEscape));
        }

        private void PlayParticle(ParticleType particleType, Vector3 position)
        {
            ParticleSystem particle = particlePool.GetParticle(particleType);
            particle.gameObject.transform.position = position;
            particle.gameObject.SetActive(true);
            particle.Play();

            coroutineRunner.StartCor(ReturnToPoolAfterPlay(particleType, particle));
        }

        private IEnumerator ReturnToPoolAfterPlay(ParticleType particleType, ParticleSystem particle)
        {
            yield return new WaitWhile(() => particle.isPlaying);

            particle.Stop();
            particle.gameObject.SetActive(false);
            particlePool.ReturnParticle(particleType, particle);
        }

        private IEnumerator RunWithDelayCoroutine<T1, T2>(Action<T1, T2> method, T1 param1, T2 param2, float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            method?.Invoke(param1, param2);
        }

        private void OnDestroy()
        {
            eventManager.Unsubscribe<OnLetterChecked>(this);
            eventManager.Unsubscribe<OnWordCompleted>(this);
            eventManager.Unsubscribe<OnVictory>(this);
            eventManager.Unsubscribe<OnDeath>(this);
        }
    }
}
