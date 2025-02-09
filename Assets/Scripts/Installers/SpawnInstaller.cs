using Pools;
using Spawn;
using Zenject;

public class SpawnInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<ISpawnableObjectProvider>().To<SpawnableObjectPool>().AsSingle();
        Container.Bind<ISceneObjectProvider>().To<SceneObjectPool>().AsSingle();

        Container.Bind<ISpawner>().WithId("Decor").To<DecorativeObjectSpawner>().AsSingle();
        Container.Bind<ISpawner>().WithId("Interact").To<InteractableObjectSpawner>().AsSingle();
        Container.Bind<ISpawner>().WithId("Missile").To<MissileSpawner>().AsSingle();
        Container.Bind<SpawnHandler>().AsSingle().NonLazy();
        
        Container.Bind<SceneObjectSpawner>().AsSingle().NonLazy();
    }
}
