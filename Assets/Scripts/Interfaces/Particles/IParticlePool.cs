using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IParticlePool
{
    public ParticleSystem GetParticle(ParticleType particleType);
    public void ReturnParticle(ParticleType particleType, ParticleSystem particle);
}
