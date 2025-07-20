# Projectile System

This document describes a simple, performance friendly projectile architecture used in the project.

## Goals

- Avoid running an `Update` method on every projectile instance.
- Manage all projectiles from a single point.
- Follow SOLID principles so new projectile types can easily be added.

## Core Interfaces

### `IProjectile`
```csharp
public interface IProjectile
{
    void Initialize(Vector3 position, Vector3 direction, float speed, float maxRange, float damage);
    void Tick(float deltaTime);
    void OnHit();
    bool IsActive { get; }
    float Damage { get; }
}
```
This interface abstracts projectile behaviour, enabling custom implementations and facilitating unit testing.

### `VisualProjectile`
A concrete `MonoBehaviour` that moves in the scene. It tracks travelled distance and disables itself when the range is exceeded.

### `ProjectileManager`
A singleton-like `MonoBehaviour` that updates all registered projectiles once per frame.

### `Shooter`
Responsible for spawning projectiles. It requests a projectile instance from `IPoolManager`, initializes it and registers it with `ProjectileManager`.

## Pool Integration

`Shooter` obtains projectiles via `IPoolManager.GetFromPool` and registers them with `ProjectileManager`. When a `VisualProjectile` reports a hit or reaches its range, `ProjectileManager` returns it to the pool.
