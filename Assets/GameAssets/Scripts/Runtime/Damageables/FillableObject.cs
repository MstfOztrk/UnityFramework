using UnityEngine;

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
