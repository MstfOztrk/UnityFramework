using System;
using UnityEngine;

public abstract class BaseShooter : MonoBehaviour, IShooter
{
    public event Action OnShoot;

    [SerializeField] protected float fireRate = 0.2f;
    [SerializeField] protected float fireRange = 20f;
    [SerializeField] protected int bulletCount = 1;
    [SerializeField, Range(0f,1f)] protected float critChance = 0f;
    [SerializeField] protected float critMultiplier = 2f;

    private float fireTimer;
    private bool isShooting;

    protected virtual void Update()
    {
        if (!isShooting) return;

        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0f)
        {
            fireTimer = fireRate;
            ShootInternal();
            OnShoot?.Invoke();
        }
    }

    public void StartShooting()
    {
        isShooting = true;
        fireTimer = 0f;
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    protected virtual void ShootInternal()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            Vector3 dir = GetDirection(i);
            bool isCrit = TryRollCrit(out float mult);
            HandleShoot(dir, isCrit, mult);
        }
    }

    protected bool TryRollCrit(out float multiplier)
    {
        if (UnityEngine.Random.value < critChance)
        {
            multiplier = critMultiplier;
            return true;
        }
        multiplier = 1f;
        return false;
    }

    protected abstract Vector3 GetDirection(int index);
    protected abstract void HandleShoot(Vector3 direction, bool isCrit, float critMul);
}
