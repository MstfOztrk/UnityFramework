# Shooter System

This document describes an extensible shooter architecture used in the project.  
Shooters abstract firing logic and can easily be extended for different patterns.

## Interfaces

### `IShooter`
```csharp
public interface IShooter
{
    void StartShooting();
    void StopShooting();
    event Action OnShoot;
}
```

## Base Implementation

### `BaseShooter`
`BaseShooter` contains the common firing loop. It handles fire rate, crit chance
and invokes `HandleShoot` for derived classes:
```csharp
public abstract class BaseShooter : MonoBehaviour, IShooter
{
    public event Action OnShoot;
    protected float fireRate = 0.2f;
    protected float fireRange = 20f;
    protected int bulletCount = 1;
    protected float critChance = 0f;       // 0..1 probability
    protected float critMultiplier = 2f;    // damage multiplier
    ...
}
```
`TryRollCrit` returns whether a shot is critical and provides the multiplier.
Derived shooters only implement `GetDirection` and `HandleShoot`.

