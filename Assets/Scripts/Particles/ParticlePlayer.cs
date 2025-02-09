﻿using System.Collections;
using UnityEngine;

namespace Particle
{
    public class ParticlePlayer : IParticlePlayer
    {
        private IParticlePool particlePool;        
        private ICoroutineRunner coroutineRunner;        

        public ParticlePlayer(IParticlePool particlePool, ICoroutineRunnerHolder runnerHolder)
        {
            this.particlePool = particlePool;            
            coroutineRunner = runnerHolder.CoroutineRunner;                      
        }         

        public void PlayParticle(ParticleType particleType, Vector3 position)
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
    }
}
