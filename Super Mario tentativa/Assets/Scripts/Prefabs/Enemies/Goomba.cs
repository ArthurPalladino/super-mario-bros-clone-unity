using UnityEngine;

public class Goomba : MonoBehaviour
{
    [SerializeField] float dirToWalk;
    [SerializeField] float moveSpeed;

    [SerializeField] Sprite dyingSprite;
    Rigidbody2D rb;
    void Start()
    {

        dirToWalk = Random.Range(0f, 1f) > 0.5f ? -1f : 1f; ;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        dirToWalk *= -1;
    }

    void FixedUpdate()
    {
        Walk();
    }
    void Walk()
    {
        rb.linearVelocity = new Vector2(dirToWalk*moveSpeed, rb.linearVelocityY);
    }
}
