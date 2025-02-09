using Zenject;
using Sounds;

public class SoundInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<ISoundLibrary>().To<SoundLibrary>().AsSingle();
        Container.Bind<ISoundEffectPlayer>().To<SoundEffectPlayer>().AsSingle();
        Container.Bind<IMusicPlayer>().To<MusicPlayer>().AsSingle();

        Container.Bind<SoundEffectHandler>().AsSingle().NonLazy();
        Container.Bind<MusicHandler>().AsSingle().NonLazy();
    }
}
