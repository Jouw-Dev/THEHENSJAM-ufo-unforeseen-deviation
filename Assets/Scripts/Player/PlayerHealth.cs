using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Life")]
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _currentHealth;
    private bool _isDead;

    [Header("Interface")]
    [SerializeField] private GameObject gameOverPanel;

    [Header("Disable on Death")]
    [SerializeField] private MonoBehaviour[] scriptsToDisable;

    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public bool IsDead { get => _isDead; set => _isDead = value; }
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damege) 
    {
        if (_isDead || damege <= 0f) return;

        _currentHealth = Mathf.Max(0f, _currentHealth - damege);

        if (_currentHealth <= 0f) Die();

    }

    private void Die() 
    {
        if (_isDead) return;

        _isDead = true;

        GameOverManager gameOverManager = FindFirstObjectByType<GameOverManager>();

        if (gameOverManager != null) gameOverManager.GameOver();
        else Debug.LogWarning("GameOverManager não encontrado");
    }

}
