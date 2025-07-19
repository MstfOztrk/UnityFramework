
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UniRx;
using Zenject;
using System;
using System.Collections.Generic;

public class LevelManager : ILevelManager, IDisposable
{
    public IObserver<string> LoadLevelRequest => loadRequests;
    public IReadOnlyReactiveProperty<GameObject> CurrentLevel => currentLevel;
    private readonly ReactiveProperty<GameObject> currentLevel = new ReactiveProperty<GameObject>();
    private AsyncOperationHandle<IList<GameObject>> loadHandle;
    private readonly Subject<string> loadRequests = new Subject<string>();
    private readonly CompositeDisposable disposables = new CompositeDisposable();
    private const string levelLabel = "Level";

    [Inject]
    public LevelManager()
    {
        loadRequests
            .Subscribe(levelName => ProcessLoad(levelName))
            .AddTo(disposables);
    }

    private void ProcessLoad(string levelName)
    {
        UnloadLevel();

        loadHandle = Addressables.LoadAssetsAsync<GameObject>(levelLabel, null);
        loadHandle.Completed += handle =>
        {
            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError($"Level Load ERROR: {levelName}");
                return;
            }

            IList<GameObject> results = handle.Result;
            for (int i = 0; i < results.Count; i++)
            {
                GameObject prefab = results[i];
                if (prefab.name == levelName)
                {
                    var instance = UnityEngine.Object.Instantiate(prefab);
                    currentLevel.Value = instance;
                    return;
                }
            }

            Debug.LogError($"Level Can Not Found: {levelName}");
        };
    }

    public void UnloadLevel()
    {
        GameObject existing = currentLevel.Value;
        if (existing != null)
        {
            UnityEngine.Object.Destroy(existing);
            currentLevel.Value = null;
        }

        if (loadHandle.IsValid())
        {
            Addressables.Release(loadHandle);
        }
    }

    public void Dispose()
    {
        disposables.Dispose();
    }
}