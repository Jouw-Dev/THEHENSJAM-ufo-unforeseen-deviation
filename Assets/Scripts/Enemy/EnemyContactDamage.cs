using UnityEngine;

public class EnemyContactDamage : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private float damage = 10f;
    [SerializeField] private float damageInterval = 1f;

    private float nextDamageTime;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(Time.time < nextDamageTime) return;

        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if(playerHealth == null || playerHealth.IsDead) return;

        playerHealth.TakeDamage(damage);
        nextDamageTime = Time.time + damageInterval;
    }
}
