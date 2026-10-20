using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private Image fill;

    private void Start()
    {
        UpdateHealthBar();
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar() 
    {
        if (enemyHealth == null || fill == null) return;

        fill.fillAmount = (float)enemyHealth.CurrentHealth / enemyHealth.MaxHealth;
    }
}
