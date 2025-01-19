using GameStates;
using Zenject;

public class GameStateInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<IStateFactory>().To<StateFactory>().AsSingle().NonLazy();
        Container.BindInterfacesTo<GameStateManager>().AsSingle().NonLazy();
        Container.Bind<CountdownState>().AsSingle();
        Container.Bind<MovingState>().AsSingle();
        Container.Bind<LossState>().AsSingle();
        Container.Bind<VictoryState>().AsSingle();
        Container.Bind<SafeSubstate>().AsSingle();
        Container.Bind<InteractiveSubstate>().AsSingle();
        Container.Bind<MovingStateManager>().AsSingle();       
    }
}
