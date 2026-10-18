using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Transform player;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Nenhum objeto com a tag Player foi encontrado");
        }
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        Vector2 direction = ((Vector2)player.position - rb.position).normalized;

        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

}
