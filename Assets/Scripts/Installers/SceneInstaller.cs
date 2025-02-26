using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IEventManager>().To<EventBus>().AsSingle();
        Container.Install<CameraInstaller>();
        Container.Install<WordControlInstaller>();
        Container.Install<ParticleInstaller>();
        Container.Install<SpawnInstaller>();        
        Container.Install<MovementInstaller>();        
        Container.Install<SoundInstaller>();
        Container.BindInterfacesTo<Instantiator>().AsSingle().NonLazy();
        Container.Install<PlayerBehaviourInstaller>();
        Container.Install<GameStateInstaller>();
        Container.Bind<CollisionHandler>().AsSingle().NonLazy();
    }
}
