using GameStates;
using Zenject;
using GameStates.Moving;

public class GameStateInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<CountdownState>().AsSingle();
        Container.Bind<LossState>().AsSingle();
        Container.Bind<VictoryState>().AsSingle();
        InstallMovingState();

        Container.Bind<IStateInitializer>().To<GameStateInitializer>().AsSingle();
        Container.BindInterfacesTo<GameStateSwitcher>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameStateHandler>().AsSingle().NonLazy();
    }

    private void InstallMovingState()
    {
        Container.Bind<MovingState>().AsSingle();
        Container.Bind<MissileSubstate>().AsSingle();
        Container.Bind<SafeSubstate>().AsSingle();
        Container.Bind<InteractiveSubstate>().AsSingle();
        Container.BindInterfacesAndSelfTo<SubstateInitializer>().AsSingle();
        Container.BindInterfacesAndSelfTo<SubstateSwitcher>().AsSingle();
        Container.Bind<SubstateHandler>().AsSingle().NonLazy();        
    }
}
