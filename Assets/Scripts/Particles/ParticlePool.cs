using System.Collections.Generic;
using UnityEngine;

namespace Particle
{
    public class ParticlePool : IPoolInitializable, IParticlePool
    {
        private ParticleCollection particleCollection;

        private Dictionary<ParticleType, Queue<ParticleSystem>> poolDictionary;
        private GameObject poolHolder;

        public ParticlePool(ParticleCollection particleCollection)
        {
            this.particleCollection = particleCollection;

            InitializePools();
        }

        public void InitializePools()
        {
            poolDictionary = new Dictionary<ParticleType, Queue<ParticleSystem>>();

            poolHolder = new GameObject("Particle Pool");

            foreach (var particleObject in particleCollection.ParticleObjects)
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
    }
}
