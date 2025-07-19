using UnityEngine;

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
