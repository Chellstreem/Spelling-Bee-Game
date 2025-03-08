using Zenject;
using PlayerMobility;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMobilityInstaller", menuName = "Installers/PlayerMobilityInstaller")]
public class PlayerMobilityInstaller : ScriptableObjectInstaller
{
    [SerializeField] private PlayerMobilityConfig playerMobilityConfig;

    public override void InstallBindings()
    {
        Container.Bind<PlayerMobilityConfig>()
            .FromInstance(playerMobilityConfig)
            .AsSingle();

        Container.BindInterfacesTo<PlayerMovement>().AsSingle();
        Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerMovementHandler>().AsSingle().NonLazy();
    }
}
