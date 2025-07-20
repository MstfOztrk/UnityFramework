using UnityEngine;

/// <summary>
/// Defines the common behaviour of any projectile.
/// </summary>
public interface IProjectile
{
    /// <summary>
    /// Initializes the projectile instance.
    /// </summary>
    /// <param name="position">Spawn position.</param>
    /// <param name="direction">Normalized direction.</param>
    /// <param name="speed">Movement speed.</param>
    /// <param name="maxRange">Maximum travel distance.</param>
    /// <param name="damage">Damage dealt on hit.</param>
    void Initialize(Vector3 position, Vector3 direction, float speed, float maxRange, float damage);

    /// <summary>
    /// Called every frame by <see cref="ProjectileManager"/>.
    /// </summary>
    /// <param name="deltaTime">Time since last tick.</param>
    void Tick(float deltaTime);

    /// <summary>
    /// Invoked when the projectile hits something or expires.
    /// </summary>
    void OnHit();

    /// <summary>
    /// Whether the projectile is currently active.
    /// </summary>
    bool IsActive { get; }

    /// <summary>
    /// Damage dealt on hit.
    /// </summary>
    float Damage { get; }
}
