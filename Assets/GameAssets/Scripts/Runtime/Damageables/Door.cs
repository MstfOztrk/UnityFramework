using UnityEngine;

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
