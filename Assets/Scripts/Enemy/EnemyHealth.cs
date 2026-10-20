using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Life")]
    [SerializeField] private int maxHealth = 3;

    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage (int damage) 
    {
        if (damage <= 0 || currentHealth <= 0) return;

        currentHealth -= damage;

        // Debug.Log($"{gameObject.name}: {currentHealth}/{maxHealth} HP");

        if (currentHealth <= 0) Die();
    }

    public void Die () 
    {
        Destroy(gameObject);
    }
}
