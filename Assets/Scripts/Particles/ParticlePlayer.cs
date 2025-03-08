using System.Collections;
using UnityEngine;

namespace Particles
{
    public class ParticlePlayer : IParticlePlayer
    {
        private readonly IParticlePool particlePool;        
        private readonly ICoroutineRunner coroutineRunner;        

        public ParticlePlayer(IParticlePool particlePool, ICoroutineRunner coroutineRunner)
        {
            this.particlePool = particlePool;            
            this.coroutineRunner = coroutineRunner;                      
        }         

        public void PlayParticle(ParticleType particleType, Vector3 position)
        {
            ParticleSystem particle = particlePool.GetParticle(particleType);            
            particle.gameObject.transform.position = position;
            particle.gameObject.SetActive(true);
            particle.Play();

            coroutineRunner.StartCor(ReturnToPoolAfterPlay(particleType, particle));
        }

        public void PlayParticle(ParticleType particleType, Vector3 position, float delay)
        {
            coroutineRunner.StartCor(DelayedParticleCoroutine(particleType, position, delay));
        }

        private IEnumerator DelayedParticleCoroutine(ParticleType particleType, Vector3 position, float duration)
        {
            yield return new WaitForSeconds(duration);
            PlayParticle(particleType, position);
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
