using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Central manager that updates all active projectiles.
/// </summary>
public class ProjectileManager : MonoBehaviour
{
    private readonly List<IProjectile> _projectiles = new();

    /// <summary>
    /// Registers a projectile to be updated each frame.
    /// </summary>
    public void RegisterProjectile(IProjectile projectile)
    {
        _projectiles.Add(projectile);
    }

    private void Update()
    {
        float dt = Time.deltaTime;

        for (int i = _projectiles.Count - 1; i >= 0; i--)
        {
            var p = _projectiles[i];
            if (!p.IsActive)
            {
                _projectiles.RemoveAt(i);
                continue;
            }
            p.Tick(dt);
        }
    }
}
