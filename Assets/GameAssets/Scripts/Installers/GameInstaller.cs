using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<LevelManager>().AsSingle().NonLazy();

        var projectileManager = Container.InstantiateComponentOnNewGameObject<ProjectileManager>("ProjectileManager");
        Container.Bind<ProjectileManager>().FromInstance(projectileManager).AsSingle().NonLazy();
    }

}
