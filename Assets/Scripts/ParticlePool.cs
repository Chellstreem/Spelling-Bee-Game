using System.Collections.Generic;
using UnityEngine;


public class ParticlePool : MonoBehaviour, IPool
{
    [SerializeField] private ParticleCollection particleCollection;

    private Dictionary<ParticleObject.ParticleType, Queue<ParticleSystem>> poolDictionary;

    public void Initialize() => InitializePools();

    public void InitializePools()
    {
        poolDictionary = new Dictionary<ParticleObject.ParticleType, Queue<ParticleSystem>>();

        foreach (var particleObject in particleCollection.ParticleObjects)
        {
            var particleType = particleObject.Type;

            if (!poolDictionary.ContainsKey(particleType))
                poolDictionary[particleType] = new Queue<ParticleSystem>();


            for (int i = 0; i < particleObject.Amount; i++)
            {
                GameObject obj = Instantiate(particleObject.Prefab, transform);
                obj.SetActive(false);

                poolDictionary[particleType].Enqueue(obj.GetComponent<ParticleSystem>());
            }
        }
    }

    public ParticleSystem GetParticle(ParticleObject.ParticleType particleType)
    {
        if (!poolDictionary.ContainsKey(particleType) || poolDictionary[particleType].Count == 0)
        {
            Debug.LogWarning($"Партикл типа {particleType} не найден.");
            return null;
        }

        ParticleSystem particle = poolDictionary[particleType].Dequeue();        
        return particle;
    }

    public void ReturnParticle(ParticleObject.ParticleType particleType, ParticleSystem particle)
    {        
        poolDictionary[particleType].Enqueue(particle);
    }
}
