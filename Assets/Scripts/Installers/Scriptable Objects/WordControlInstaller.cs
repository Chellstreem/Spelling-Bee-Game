using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "WordControlInstaller", menuName = "Installers/WordControlInstaller")]
public class WordControlInstaller : ScriptableObjectInstaller
{
    [SerializeField] private WordControlConfig config;

    public override void InstallBindings()
    {
        Container.Bind<WordControlConfig>()
            .FromInstance(config)
            .AsSingle();

        Container.Bind<IWordMasker>().To<WordMasker>().AsSingle();
        Container.BindInterfacesAndSelfTo<CurrentWordHandler>().AsSingle();        
        Container.BindInterfacesAndSelfTo<MaskedWordHandler>().AsSingle();            
    }
}
