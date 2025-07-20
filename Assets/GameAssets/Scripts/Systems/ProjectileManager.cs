using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Central manager that updates all active projectiles.
/// </summary>
public class ProjectileManager : MonoBehaviour
{
    private readonly List<IProjectile> projectiles = new();

    [Inject] private IPoolManager poolManager;

    /// <summary>
    /// Registers a projectile to be updated each frame.
    /// </summary>
    public void RegisterProjectile(IProjectile projectile)
    {
        projectiles.Add(projectile);
    }

    private void Update()
    {
        float dt = Time.deltaTime;

        for (int i = projectiles.Count - 1; i >= 0; i--)
        {
            var p = projectiles[i];
            if (!p.IsActive)
            {
                if (p is VisualProjectile visual)
                {
                    poolManager.ReturnToPool(visual.PoolType, visual.gameObject);
                }
                projectiles.RemoveAt(i);
                continue;
            }
            p.Tick(dt);
        }
    }
}
