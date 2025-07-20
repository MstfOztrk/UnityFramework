using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;
public enum PoolType
{
    Enemy,
    Projectile,
}


[System.Serializable]
public class PoolObject
{
    public PoolType poolType;
    public AssetReference prefabRef;
}
public class PoolManager : MonoBehaviour, IPoolManager
{
    private readonly Dictionary<PoolType, GameObject> prefabDict = new();
    private readonly Dictionary<PoolType, Queue<GameObject>> poolDict = new();

    public async Task InitializeFromChapterSO(ChapterPoolSO chapterPoolSO)
    {
        prefabDict.Clear();
        poolDict.Clear();

        var loadTasks = new List<Task>();
        foreach (var poolObj in chapterPoolSO.poolObjects)
        {
            loadTasks.Add(LoadAndRegister(poolObj));
        }
        await Task.WhenAll(loadTasks);
    }

    private async Task LoadAndRegister(PoolObject poolObj)
    {
        var handle = poolObj.prefabRef.LoadAssetAsync<GameObject>();
        await handle.Task;
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            prefabDict[poolObj.poolType] = handle.Result;
            poolDict[poolObj.poolType] = new Queue<GameObject>();
        }
        else
        {
            Debug.LogError($"Failed to load prefab for {poolObj.poolType}");
        }
    }

    public GameObject GetFromPool(PoolType type, Vector3 pos, Quaternion rot)
    {
        if (!poolDict.TryGetValue(type, out var queue))
            throw new Exception($"PoolType {type} is not registered!");

        GameObject obj;
        if (queue.Count > 0)
        {
            obj = queue.Dequeue();
            obj.SetActive(true);
        }
        else
        {
            obj = Instantiate(prefabDict[type]);
        }
        obj.transform.SetPositionAndRotation(pos, rot);
        return obj;
    }

    public void ReturnToPool(PoolType type, GameObject obj)
    {
        obj.SetActive(false);
        poolDict[type].Enqueue(obj);
    }
}
