using Zenject;

public class MovementInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<PlayerMovement>().AsSingle();
        Container.Bind<IInputHandler>().To<InputHandler>().AsSingle().NonLazy();
    }
}
