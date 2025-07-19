using System.Threading.Tasks;
using UnityEngine;

public interface IPoolManager
{
    Task InitializeFromChapterSO(ChapterPoolSO chapterPoolSO);
    GameObject GetFromPool(PoolType type, Vector3 pos, Quaternion rot);
    void ReturnToPool(PoolType type, GameObject obj);
}