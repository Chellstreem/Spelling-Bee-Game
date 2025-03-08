using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PlayerHealthInstaller ", menuName = "Installers/PlayerHealthInstaller")]
public class PlayerHealthInstaller : ScriptableObjectInstaller
{
    [SerializeField] private PlayerHealthConfig config;

    public override void InstallBindings()
    {
        Container.Bind<PlayerHealthConfig>()
            .FromInstance(config)
            .AsSingle();

        Container.BindInterfacesTo<PlayerHealth>().AsSingle();
        Container.BindInterfacesTo<PlayerHealthBarController>().AsSingle().NonLazy();
    }
}
