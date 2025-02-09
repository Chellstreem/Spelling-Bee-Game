using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ConfigInstaller : MonoInstaller
{
    [SerializeField] private GameConfig gameConfig;
    [SerializeField] private SpawnableObjectCollection spawnableCollection;
    [SerializeField] private SceneObjectCollection sceneObjectCollection;
    [SerializeField] private ParticleCollection particleCollection;
    [SerializeField] private SoundCollection soundEffectCollection;

    public override void InstallBindings()
    {
        Container.Bind<GameConfig>().FromInstance(gameConfig).AsSingle();
        Container.Bind<SpawnableObjectCollection>().FromInstance(spawnableCollection).AsSingle();
        Container.Bind<SceneObjectCollection>().FromInstance(sceneObjectCollection).AsSingle();
        Container.Bind<ParticleCollection>().FromInstance(particleCollection).AsSingle();
        Container.Bind<SoundCollection>().FromInstance(soundEffectCollection).AsSingle();
    }
}
