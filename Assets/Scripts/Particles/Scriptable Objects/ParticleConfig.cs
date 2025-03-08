using UnityEngine;

[CreateAssetMenu(fileName = "ParticleConfig", menuName = "Scriptable Objects/Particle/ParticleConfig")]
public class ParticleConfig : ScriptableObject
{
    [SerializeField] private ParticleObject[] particleObjects;

    public ParticleObject[] ParticleObjects => particleObjects;
}
