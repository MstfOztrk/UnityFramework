using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UniRx;
using Zenject;
using System;
using System.Collections.Generic;

public interface ILevelManager
{
    public IObserver<string> LoadLevelRequest { get; }
    public IReadOnlyReactiveProperty<GameObject> CurrentLevel { get; }
    public void UnloadLevel();
}