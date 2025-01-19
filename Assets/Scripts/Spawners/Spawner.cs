using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : IInteractableSpawner
{
    public abstract float SpawnFrequency { get; }

    public abstract void StartSpawning();

    public abstract void StopSpawning();
}
