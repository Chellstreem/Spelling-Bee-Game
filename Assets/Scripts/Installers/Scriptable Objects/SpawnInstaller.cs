using Spawn;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SpawnInstaller", menuName = "Installers/SpawnInstaller")]
public class SpawnInstaller : ScriptableObjectInstaller
{
    [SerializeField] private SpawnConfig spawnConfig;
    public override void InstallBindings()
    {
        Container.Bind<SpawnConfig>()
            .FromInstance(spawnConfig)
            .AsSingle();

        Container.BindInterfacesTo<SpawnableObjectPool>().AsSingle();        
        Container.BindInterfacesTo<SceneObjectPool>().AsSingle();
        Container.Bind<PoolInitializer>().AsSingle().NonLazy();

        Container.Bind<ISpawner>()
            .WithId(SpawnerType.Decorative)
            .To<DecorativeObjectSpawner>()
            .AsSingle();

        Container.Bind<ISpawner>()
            .WithId(SpawnerType.Interactable)
            .To<InteractableObjectSpawner>()
            .AsSingle();

        Container.Bind<ISpawner>()
            .WithId(SpawnerType.Missile)
            .To<MissileSpawner>()
            .AsSingle();

        Container.Bind<SceneObjectSpawner>().AsSingle().NonLazy();
        Container.Bind<SpawnEventHandler>().AsSingle().NonLazy();        
    }
}
