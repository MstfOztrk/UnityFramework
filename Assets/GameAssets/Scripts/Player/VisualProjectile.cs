using UnityEngine;

/// <summary>
/// Concrete projectile that exists visually in the scene.
/// </summary>
public class VisualProjectile : MonoBehaviour, IProjectile
{
    private Vector3 direction;
    private float speed;
    private bool isActive;
    private float maxRange;
    private float travelled;
    private float damage;

    /// <summary>
    /// Pool type for this projectile.
    /// </summary>
    public PoolType PoolType { get; set; } = PoolType.Projectile;

    public bool IsActive => isActive;
    public float Damage => damage;

    public void Initialize(Vector3 position, Vector3 direction, float speed, float maxRange, float damage)
    {
        transform.position = position;
        this.direction = direction.normalized;
        this.speed = speed;
        this.maxRange = maxRange;
        travelled = 0f;
        this.damage = damage;
        isActive = true;
        gameObject.SetActive(true);
    }

    public void Tick(float deltaTime)
    {
        if (!isActive) return;

        Vector3 movement = direction * speed * deltaTime;
        transform.position += movement;
        travelled += movement.magnitude;

        if (travelled >= maxRange)
        {
            OnHit();
        }
    }

    public void OnHit()
    {
        if (!isActive) return;
        isActive = false;
        // pooling handled by ProjectileManager
    }
}
