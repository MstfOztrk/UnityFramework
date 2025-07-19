using UnityEngine;
using Zenject;
public class FactoryInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
    }
}
