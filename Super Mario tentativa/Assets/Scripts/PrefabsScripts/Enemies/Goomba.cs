using System.Collections;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    [SerializeField] float dirToWalk;
    [SerializeField] float moveSpeed;

    [SerializeField] Sprite dyingSprite;
    BoxCollider2D topCollider;

    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    bool isAlive = true;
    
    void Start()
    {
        topCollider = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        dirToWalk = Random.Range(0f, 1f) > 0.5f ? -1f : 1f; ;
        //dirToWalk = -1;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isAlive)
        {
            
            if (collision.otherCollider == topCollider)
            {
                isAlive=false;
                StartCoroutine(Die());
            }
            else
            {
                collision.gameObject.GetComponent<PlayerDeath>().TakenDamage();
            }
            return;
        }
        dirToWalk *= -1;
    }

    IEnumerator Die()
    {
        rb.angularVelocity = 0;
        rb.linearVelocityX = 0;
        animator.enabled = false;
        moveSpeed = 0;
        spriteRenderer.sprite = dyingSprite;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }
    void FixedUpdate()
    {
        if(isAlive) Walk();
        
    }
    void Walk()
    {
        rb.linearVelocity = new Vector2(dirToWalk*moveSpeed, rb.linearVelocityY);
    }
}
