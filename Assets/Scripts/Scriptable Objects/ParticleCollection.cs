using UnityEngine;

[CreateAssetMenu(fileName = "ParticleCollection", menuName = "Scriptable Objects/ParticleCollection")]
public class ParticleCollection : ScriptableObject
{
    [SerializeField] private ParticleObject[] particleObjects;

    public ParticleObject[] ParticleObjects => particleObjects;
}
