using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float damageInterval = 1f;

    private float nextDamageTime;

    private void OnCollisionStay2D(Collision2D collision)
    {
        TryDamagePlayer(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        TryDamagePlayer(other.gameObject);
    }

    private void TryDamagePlayer(GameObject target) 
    {
        if (Time.time < nextDamageTime) return;

        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();

        if (playerHealth == null) return;

        playerHealth.TakeDamage(damage);
        nextDamageTime = Time.time + damageInterval;
    }
}
