using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [Inject] private IPoolManager _poolManager;

    [Button]
    public void SpawnEnemy(Vector3 pos)
    {
        var obj = _poolManager.GetFromPool(PoolType.Enemy, Vector3.zero, Quaternion.identity);
        // ...
    }

    public void KillEnemy(GameObject enemy)
    {
        _poolManager.ReturnToPool(PoolType.Enemy, enemy);
    }
}