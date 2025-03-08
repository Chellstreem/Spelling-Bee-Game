using Zenject;
using UnityEngine;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IEventManager>().To<EventBus>().AsSingle();
        Container.Bind<IScaler>().To<ScaleEffect>().AsSingle();
        Container.BindInterfacesTo<LetterGenerator>().AsSingle().NonLazy();        
    }
}
