using UnityEngine;
using Zenject;
using Spawn;
using Pools;
using GameStates;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {        
        Container.Bind<IEventManager>().To<EventBus>().AsSingle();        
        Container.Install<WordHandlerInstaller>();
        Container.Install<ParticleInstaller>();
        Container.Install<SpawnInstaller>();
        Container.Install<MovementInstaller>();
        Container.Install<SoundInstaller>();
        Container.BindInterfacesTo<Instantiator>().AsSingle().NonLazy();
        Container.Install<GameStateInstaller>();        
    }
}
