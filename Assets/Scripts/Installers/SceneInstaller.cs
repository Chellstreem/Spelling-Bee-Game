using UnityEngine;
using Zenject;
using Spawners;
using Pools;
using GameStates;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private ConfigInstaller configInstaller;

    public override void InstallBindings()
    {
        Container.Bind<IEventManager>().To<EventBus>().AsSingle();
        Container.Install<WordHandlerInstaller>();
        Container.Install<ParticleInstaller>();
        Container.Install<SpawnInstaller>();        
        Container.Install<MovementInstaller>();
        Container.BindInterfacesTo<Instantiator>().AsSingle().NonLazy();
        Container.Install<GameStateInstaller>();
        Container.Bind<SceneUIStore>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}
