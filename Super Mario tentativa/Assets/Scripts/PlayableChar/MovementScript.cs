using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    Renderer rd;
    Rigidbody2D rb;

    bool Jumping = false;
    void Start()
    {
        rd = gameObject.GetComponent<Renderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        var playerInput = Input.GetAxis("Horizontal");

        if (playerInput != 0)
        {
            float halfWidth = Camera.main.orthographicSize * Camera.main.aspect;
            //Mantém atualizando o spriteSize para futuras atualizações de sprites, como aumento de personagem ou Yoshi.
            float spriteSize = rd.bounds.size.x / 2;
            float minX = Camera.main.transform.position.x - halfWidth + spriteSize;
            float maxX = Camera.main.transform.position.x + halfWidth - spriteSize;
            float xMove = playerInput * moveSpeed * Time.deltaTime;
            float clampedX = Mathf.Clamp(transform.position.x+xMove, minX, maxX);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
            
        }
        else
        {

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Jumping = false;
        }
    }

    void Jump()
    {
        var playerInput = Input.GetAxis("Vertical");
        if ((playerInput > 0 || Input.GetKey(KeyCode.Space)) && !Jumping)
        {
            Jumping = true;
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
    }
}
