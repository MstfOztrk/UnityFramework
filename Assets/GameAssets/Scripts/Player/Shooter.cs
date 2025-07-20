using UnityEngine;
using Zenject;

/// <summary>
/// Component responsible for spawning projectiles.
/// </summary>
public class Shooter : MonoBehaviour
{
    [SerializeField] private PoolType projectileType = PoolType.Projectile;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileRange = 20f;

    [Inject] private ProjectileManager _projectileManager;
    [Inject] private IPoolManager _poolManager;

    /// <summary>
    /// Spawns a projectile moving in the given direction.
    /// </summary>
    public void Shoot(Vector3 direction)
    {
        var obj = _poolManager.GetFromPool(projectileType, transform.position, Quaternion.identity);
        var projectile = obj.GetComponent<IProjectile>();
        if (projectile == null)
        {
            Debug.LogError("Projectile prefab does not implement IProjectile");
            return;
        }

        if (projectile is VisualProjectile visual)
        {
            visual.PoolManager = _poolManager;
            visual.PoolType = projectileType;
        }

        projectile.Initialize(transform.position, direction, projectileSpeed, projectileRange);
        _projectileManager.RegisterProjectile(projectile);
    }
}
