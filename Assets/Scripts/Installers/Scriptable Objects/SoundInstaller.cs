using Zenject;
using Sounds;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundInstaller", menuName = "Installers/SoundInstaller")]
public class SoundInstaller : ScriptableObjectInstaller
{
    [SerializeField] private SoundConfig soundConfig;

    public override void InstallBindings()
    {
        Container.Bind<SoundConfig>()
            .FromInstance(soundConfig)
            .AsSingle();

        Container.Bind<ISoundLibrary>().To<SoundPool>().AsSingle();
        Container.Bind<ISoundEffectPlayer>().To<SoundEffectPlayer>().AsSingle();
        Container.Bind<IMusicPlayer>().To<MusicPlayer>().AsSingle();
        Container.Bind<SoundEffectHandler>().AsSingle().NonLazy();
        Container.Bind<MusicHandler>().AsSingle().NonLazy();
    }
}
