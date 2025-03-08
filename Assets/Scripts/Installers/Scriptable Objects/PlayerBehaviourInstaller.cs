using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PlayerBehaviourInstaller", menuName = "Installers/PlayerBehaviourInstaller")]
public class PlayerBehaviourInstaller : ScriptableObjectInstaller
{
    [SerializeField] private PlayerBehaviourConfig playerBehaviourConfig;

    public override void InstallBindings()
    {
        Container.Bind<PlayerBehaviourConfig>()
            .FromInstance(playerBehaviourConfig)
            .AsSingle();

        Container.Bind<IPhysicsModifier>().To<PhysicsModifier>().AsSingle();
        Container.Bind<IPlayerAnimationPlayer>().To<PlayerAnimation>().AsSingle();
        Container.Bind<PlayerBehaviour>().AsSingle().NonLazy();
    }
}
