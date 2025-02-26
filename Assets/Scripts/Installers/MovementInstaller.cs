using Zenject;
using PlayerMobility;

public class MovementInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<PlayerMovement>().AsSingle();
        Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerMovementHandler>().AsSingle().NonLazy();
    }
}
