using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ChapterPool", menuName = "Game/Chapter Pool")]
public class ChapterPoolSO : ScriptableObject
{
    public List<PoolObject> poolObjects;
}