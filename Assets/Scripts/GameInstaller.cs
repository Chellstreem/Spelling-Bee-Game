using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private PlayerMovementConfig playerMovementConfig;
    [SerializeField] private ParticleCollection particles;
    [SerializeField] private SpawnablesCollection spawnablesCollection;
    [SerializeField] private SpawnerConfig spawnerConfig;


    public override void InstallBindings()
    {

    }
}
