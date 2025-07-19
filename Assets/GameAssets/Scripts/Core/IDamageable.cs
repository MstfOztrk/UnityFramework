using UnityEngine;

/// <summary>
/// Defines an object that can receive damage.
/// </summary>
public interface IDamageable
{
    /// <summary>
    /// Apply damage to the object.
    /// </summary>
    /// <param name="amount">Amount of damage.</param>
    void TakeDamage(float amount);
}
