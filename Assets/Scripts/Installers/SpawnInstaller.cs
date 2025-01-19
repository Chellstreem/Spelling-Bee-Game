using Pools;
using Spawners;
using Zenject;

public class SpawnInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<ISpawnableObjectProvider>().To<SpawnableObjectPool>().AsSingle();
        Container.Bind<ISceneObjectProvider>().To<SceneObjectPool>().AsSingle();
        Container.Bind<DecorativeObjectSpawner>().AsSingle().NonLazy();
        Container.Bind<IInteractableSpawner>().To<InteractableObjectSpawner>().AsSingle().NonLazy();
        Container.Bind<SceneObjectSpawner>().AsSingle().NonLazy();
    }
}
