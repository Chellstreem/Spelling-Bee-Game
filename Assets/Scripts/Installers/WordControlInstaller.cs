using Zenject;

public class WordControlInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<IWordMasker>().To<WordMasker>().AsSingle();
        Container.BindInterfacesAndSelfTo<CurrentWordHandler>().AsSingle();
        Container.BindInterfacesAndSelfTo<MaskedWordHandler>().AsSingle();
        Container.Bind<WordControl>().AsSingle().NonLazy();        
    }
}
