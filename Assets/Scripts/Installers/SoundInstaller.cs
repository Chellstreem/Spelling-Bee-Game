using Zenject;
using Sounds;
using System;

public class SoundInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<ISoundLibrary>().To<SoundLibrary>().AsSingle();
        Container.Bind<ISoundEffectPlayer>().To<SoundEffectPlayer>().AsSingle();
        Container.Bind<IMusicPlayer>().To<MusicPlayer>().AsSingle();

        Container.Bind<SoundEffectBehaviour>().AsSingle().NonLazy();
        Container.Bind<MusicHandler>().AsSingle().NonLazy();
    }
}
