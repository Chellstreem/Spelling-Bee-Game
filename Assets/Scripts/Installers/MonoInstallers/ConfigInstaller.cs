using UnityEngine;
using Zenject;

public class ConfigInstaller : MonoInstaller
{    
    [SerializeField] private GameConfig gameConfig;     
    [SerializeField] private SceneObjectCollection sceneObjectCollection;        

    public override void InstallBindings()
    {        
        Container.Bind<GameConfig>().FromInstance(gameConfig).AsSingle();        
        Container.Bind<SceneObjectCollection>().FromInstance(sceneObjectCollection).AsSingle();                 
    }
}
