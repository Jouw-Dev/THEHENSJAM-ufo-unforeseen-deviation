using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f;
    private Rigidbody2D rb;
    private BulletPool pool;
    private float timer;
    private bool returned;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Vector2 direction, float speed, BulletPool bulletPool)
    {
        pool = bulletPool;
        timer = lifetime;
        returned = false;

        rb.linearVelocity = direction * speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            ReturnToPool();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(returned)
            return;

        if (other.CompareTag("Enemy"))
        {
            // Debug.Log("Hit");
            ReturnToPool();
        }
    }

    public void ReturnToPool()
    {
        if(returned)
            return;

        returned = true;
        rb.linearVelocity = Vector2.zero;
        pool.ReturnBullet(this);
    }
}
