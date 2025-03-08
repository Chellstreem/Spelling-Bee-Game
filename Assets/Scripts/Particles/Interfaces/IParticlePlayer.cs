using UnityEngine;

namespace Particles
{
    public interface IParticlePlayer
    {
        public void PlayParticle(ParticleType particleType, Vector3 position);
        public void PlayParticle(ParticleType particleType, Vector3 position, float delay);
    }
}
