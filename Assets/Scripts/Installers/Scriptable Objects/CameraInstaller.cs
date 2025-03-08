using Zenject;
using Cameras;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraInstaller", menuName = "Installers/CameraInstaller")]
public class CameraInstaller : ScriptableObjectInstaller
{
    [SerializeField] private CameraConfig cameraConfig;

    public override void InstallBindings()
    {
        Container.Bind<CameraConfig>()
            .FromInstance(cameraConfig)
            .AsSingle();

        Container.Bind<ICameraGetter>().To<CameraPool>().AsSingle();
        
        Container.Bind<IUniversalCameraMover>().To<CameraMovement>().AsSingle();

        Container.Bind<ISingleCameraMover>().To<MainCameraMovement>().AsSingle();

        Container.Bind<MainCameraBehaviour>().AsSingle().NonLazy();        

        Container.BindInterfacesTo<CameraSwitcher>().AsSingle();

        Container.Bind<CameraActivationHandler>().AsSingle().NonLazy();

        Container.BindInterfacesTo<CameraShaker>().AsSingle(); 
        
        Container.Bind<CameraShakeHandler>().AsSingle().NonLazy();      
    }
}
