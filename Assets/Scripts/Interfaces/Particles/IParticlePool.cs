using UnityEngine;

namespace Particles
{
    public interface IParticlePool
    {
        public ParticleSystem GetParticle(ParticleType particleType);
        public void ReturnParticle(ParticleType particleType, ParticleSystem particle);
    }
}
