using UnityEngine;
using Zenject;

public enum InstantiatedObjectType
{
    Player,
    HealthBar
}

[CreateAssetMenu(fileName = "InstantiatedObjectInstaller", menuName = "Installers/InstantiatedObjectInstaller")]
public class InstantiatedObjectInstaller : ScriptableObjectInstaller
{
    [SerializeField] private GameObject coroutineRunnerPrefab;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject healthBarPrefab;

    public override void InstallBindings()
    {
        Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().
            FromComponentInNewPrefab(coroutineRunnerPrefab).
            AsSingle().
            NonLazy();

        Container.Bind<Transform>().WithId(InstantiatedObjectType.Player).FromComponentInNewPrefab(playerPrefab)
            .AsCached()
            .NonLazy();

        Container.Bind<Transform>().WithId(InstantiatedObjectType.HealthBar).FromComponentInNewPrefab(healthBarPrefab)
            .AsCached()
            .NonLazy();
    }
}
