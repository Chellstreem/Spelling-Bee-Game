using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WordHandlerInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<IWordMasker>().To<MaskedWordHandler>().AsSingle();
        Container.BindInterfacesAndSelfTo<CurrentWordHandler>().AsSingle();
        Container.Bind<LetterCollisionHandler>().AsSingle().NonLazy();
    }
}
