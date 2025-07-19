using UnityEngine;
using Zenject;
public class ProjectContextInstaller : MonoInstaller
{
    [SerializeField] private PoolManager poolManagerPrefab;

    public override void InstallBindings()
    {
        var poolManager = Container.InstantiatePrefabForComponent<PoolManager>(poolManagerPrefab);
        Container.Bind<IPoolManager>().FromInstance(poolManager).AsSingle().NonLazy();
    }
}
