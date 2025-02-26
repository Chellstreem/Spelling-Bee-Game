using Zenject;

public class PlayerBehaviourInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<IPhysicsModifier>().To<PhysicsModifier>().AsSingle();
        Container.Bind<IPlayerAnimationPlayer>().To<PlayerAnimation>().AsSingle();
        Container.Bind<PlayerBehaviour>().AsSingle().NonLazy();
    }
}
