using System;
using Unity.VisualScripting;
using UnityEditor.Rendering.Analytics;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] Sprite originalSprite;
    [SerializeField] Sprite deathSprite;

    [SerializeField] float deathJumpForce;
    SpriteRenderer spriteRenderer;
    MovementScript movementScript;
    Rigidbody2D rb;
    Animator animator;

    BoxCollider2D[] boxColliders;
    int curLife = 1;
    void Start()
    {
        boxColliders = gameObject.GetComponents<BoxCollider2D>();
        movementScript = gameObject.GetComponent<MovementScript>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }
    public void TakenDamage()
    {
        curLife--;
        if (curLife <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        rb.angularVelocity = 0;
        rb.linearVelocityX = 0;
        foreach(BoxCollider2D boxCollider in boxColliders)
        {
            boxCollider.enabled = false;
        }
        movementScript.CanMovement = false;
        animator.enabled = false;
        spriteRenderer.sprite= deathSprite;
        rb.AddForceY(deathJumpForce, ForceMode2D.Impulse);
        
        
    }
}
