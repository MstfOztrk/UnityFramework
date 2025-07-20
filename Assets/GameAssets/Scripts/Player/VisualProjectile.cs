using UnityEngine;

/// <summary>
/// Concrete projectile that exists visually in the scene.
/// </summary>
public class VisualProjectile : MonoBehaviour, IProjectile
{
    private Vector3 _direction;
    private float _speed;
    private bool _isActive;
    private float _maxRange;
    private float _travelled;
    private float _damage;

    /// <summary>
    /// Pool manager used to return this instance back to the pool.
    /// </summary>
    public IPoolManager PoolManager { get; set; }

    /// <summary>
    /// Pool type for this projectile.
    /// </summary>
    public PoolType PoolType { get; set; } = PoolType.Projectile;

    public bool IsActive => _isActive;
    public float Damage => _damage;

    public void Initialize(Vector3 position, Vector3 direction, float speed, float maxRange)
    {
        transform.position = position;
        _direction = direction.normalized;
        _speed = speed;
        _maxRange = maxRange;
        _travelled = 0f;
        _damage = 10f;
        _isActive = true;
        gameObject.SetActive(true);
    }

    public void Tick(float deltaTime)
    {
        if (!_isActive) return;

        Vector3 movement = _direction * _speed * deltaTime;
        transform.position += movement;
        _travelled += movement.magnitude;

        if (_travelled >= _maxRange)
        {
            OnHit();
        }
    }

    public void OnHit()
    {
        if (!_isActive) return;
        _isActive = false;
        PoolManager?.ReturnToPool(PoolType, gameObject);
    }
}
