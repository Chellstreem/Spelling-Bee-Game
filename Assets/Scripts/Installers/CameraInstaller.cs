using Zenject;
using Camera;

public class CameraInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<ICameraMover>().To<CameraMovement>().AsSingle();
        Container.Bind<IMainCameraMover>().To<MainCameraMover>().AsSingle();
        Container.Bind<ICameraShaker>().To<CameraShaker>().AsSingle();
        Container.Bind<IMainCameraShaker>().To<MainCameraShaker>().AsSingle();
        Container.Bind<MainCameraStateBehaviour>().AsSingle().NonLazy();
        Container.Bind<MainCameraShakeBehaviour>().AsSingle().NonLazy();      
    }
}
