using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moviment;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        moviment.x = Input.GetAxisRaw("Horizontal");
        moviment.y = Input.GetAxisRaw("Vertical");

        moviment = moviment.normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moviment * moveSpeed * Time.fixedDeltaTime);
    }
}
