using UnityEngine;
using Particles;

[CreateAssetMenu(fileName = "ParticleObject", menuName = "Scriptable Objects/Particle/ParticleObject")]
public class ParticleObject : ScriptableObject
{
    [SerializeField] private ParticleType type;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int amount;

    public ParticleType Type => type;
    public GameObject Prefab => prefab;
    public int Amount => amount;
}
    
