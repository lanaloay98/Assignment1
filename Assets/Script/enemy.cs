using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 movement = Vector2.zero;
    public GameObject player;
    public float speed = 1.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Fixed update
    private void FixedUpdate()
    {
        movement = ((Vector2)player.transform.position - rb.position).normalized;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
