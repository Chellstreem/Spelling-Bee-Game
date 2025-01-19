using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WordHandlerInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<IWordMasker>().To<MaskedWordHandler>().AsSingle();
        Container.Bind<ICurrentWordHandler>().To<CurrentWordHandler>().AsSingle();
        Container.Bind<WordManager>().AsSingle().NonLazy();
    }
}
