using System.Collections.Generic;
using UnityEngine;

namespace Particles
{
    public class ParticlePool : IParticlePool
    {
        private readonly ParticleConfig particleConfig;

        private Dictionary<ParticleType, Queue<ParticleSystem>> poolDictionary;
        private GameObject poolHolder;

        public ParticlePool(ParticleConfig particleConfig)
        {
            this.particleConfig = particleConfig;

            InitializePools();
        }        

        public ParticleSystem GetParticle(ParticleType particleType)
        {
            if (!poolDictionary.ContainsKey(particleType) || poolDictionary[particleType].Count == 0)
            {
                Debug.LogWarning($"Партикл типа {particleType} не найден.");
                return null;
            }

            ParticleSystem particle = poolDictionary[particleType].Dequeue();
            return particle;
        }

        public void ReturnParticle(ParticleType particleType, ParticleSystem particle)
        {
            poolDictionary[particleType].Enqueue(particle);
        }

        private void InitializePools()
        {
            poolDictionary = new Dictionary<ParticleType, Queue<ParticleSystem>>();
            poolHolder = new GameObject("Particle Pool");

            foreach (var particleObject in particleConfig.ParticleObjects)
            {
                var particleType = particleObject.Type;

                if (!poolDictionary.ContainsKey(particleType))
                    poolDictionary[particleType] = new Queue<ParticleSystem>();

                for (int i = 0; i < particleObject.Amount; i++)
                {
                    GameObject obj = Object.Instantiate(particleObject.Prefab, poolHolder.transform);
                    obj.SetActive(false);

                    poolDictionary[particleType].Enqueue(obj.GetComponent<ParticleSystem>());
                }
            }
        }
    }
}
