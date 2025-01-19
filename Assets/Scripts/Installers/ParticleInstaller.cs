using Zenject;
using Particle;

public class ParticleInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<IParticlePool>().To<ParticlePool>().AsSingle().NonLazy();
        Container.Bind<IParticlePlayer>().To<Particles>().AsSingle().NonLazy();
    }
}
