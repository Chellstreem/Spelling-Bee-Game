using Zenject;
using Particles;
using UnityEngine;

[CreateAssetMenu(fileName = "ParticleInstaller", menuName = "Installers/ParticleInstaller")]
public class ParticleInstaller : ScriptableObjectInstaller
{
    [SerializeField] private ParticleConfig particleConfig;
    public override void InstallBindings()
    {
        Container.Bind<ParticleConfig>()
            .FromInstance(particleConfig)
            .AsSingle();

        Container.Bind<IParticlePool>().To<ParticlePool>().AsSingle();
        Container.Bind<IParticlePlayer>().To<ParticlePlayer>().AsSingle().NonLazy();
        Container.Bind<ParticleHandler>().AsSingle().NonLazy();
    }
}
