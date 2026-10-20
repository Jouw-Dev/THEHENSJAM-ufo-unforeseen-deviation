using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Life")]
    [SerializeField] private int _maxHealth = 3;
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    private int _currentHealth;
    public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage (int damage) 
    {
        if (damage <= 0 || CurrentHealth <= 0) return;

        CurrentHealth -= damage;

        // Debug.Log($"{gameObject.name}: {_currentHealth}/{_maxHealth} HP");

        if (CurrentHealth <= 0) Die();
    }

    public void Die () 
    {
        Destroy(gameObject);
    }
}
