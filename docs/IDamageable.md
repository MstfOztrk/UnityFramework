# IDamageable Interface

`IDamageable` standardizes how game objects take damage. Any object
implementing this interface can define its own behavior for receiving
and reacting to damage. Doors, breakable props and even refillable
objects can share the same contract, making gameplay systems easier to
extend and maintain.

## Interface Definition
```csharp
public interface IDamageable
{
    void TakeDamage(float amount);
}
```
The interface exposes a single method `TakeDamage` which is called with
the amount of damage dealt.

## Usage Scenarios
- **Doors** – can be damaged and destroyed once their health reaches
  zero.
- **Breakable Objects** – boxes or walls that shatter when damaged.
- **Fillable Objects** – health stations or energy tanks that deplete
  when hit.

## Example Implementations

### Door
```csharp
public class Door : MonoBehaviour, IDamageable
{
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            DestroyDoor();
        }
    }

    private void DestroyDoor()
    {
        Debug.Log("Door has been destroyed.");
        Destroy(gameObject);
    }
}
```

### BreakableObject
```csharp
public class BreakableObject : MonoBehaviour, IDamageable
{
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            BreakObject();
        }
    }

    private void BreakObject()
    {
        Debug.Log("Object has broken.");
        Destroy(gameObject);
    }
}
```

### FillableObject
```csharp
public class FillableObject : MonoBehaviour, IDamageable
{
    public float fillAmount = 100f;

    public void TakeDamage(float amount)
    {
        fillAmount -= amount;
        if (fillAmount <= 0f)
        {
            Debug.Log("Fillable object is depleted.");
            Destroy(gameObject);
        }
    }
}
```

## Benefits
- **Modularity & Extensibility** – new damageable objects can be added
  simply by implementing the interface.
- **Reusability** – the same damage handling code can be shared across
  different object types.
- **Clean Code** – keeps damage logic localized to each object.
- **SOLID Principles** – aligns with ISP and SRP by giving each object
  a single responsibility for handling its own damage logic.
