using Zenject;
using Particles;

public class ParticleInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<IParticlePool>().To<ParticlePool>().AsSingle();
        Container.Bind<IParticlePlayer>().To<ParticlePlayer>().AsSingle().NonLazy();
        Container.Bind<ParticleHandler>().AsSingle().NonLazy();
    }
}
