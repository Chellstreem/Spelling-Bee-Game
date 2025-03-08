using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PlayerPerfomanceInstaller", menuName = "Installers/PlayerPerfomanceInstaller")]
public class PlayerPerfomanceInstaller : ScriptableObjectInstaller
{
    [SerializeField] private PlayerPerfomanceConfig config;

    public override void InstallBindings()
    {
        Container.Bind<PlayerPerfomanceConfig>()
            .FromInstance(config)
            .AsSingle();

        Container.Bind<LetterChecker>().AsSingle().NonLazy();
        Container.Bind<CorrectLetterHandler>().AsSingle().NonLazy();
        Container.Bind<WrongLetterHandler>().AsSingle().NonLazy();        
        Container.Bind<IDisposable>().To<PlayerPerfomanceHandler>().AsSingle().NonLazy();
    }
}
