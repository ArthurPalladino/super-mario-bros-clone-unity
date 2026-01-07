using UnityEngine;
using UnityEngine.AI;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] Sprite originalSprite;
    [SerializeField] Sprite deathSprite;

    [SerializeField] float deathJumpForce;
    
    [SerializeField] float totalBlinkingTime;
    [SerializeField] float blinkingDuration;
    
    float curBlinkingTime;
    float curBlinkingDuration;
    SpriteRenderer spriteRenderer;
    MovementScript movementScript;
    Rigidbody2D rb;
    Animator animator;

    CapsuleCollider2D capsuleCollider;

    Collider2D[] allColliders;

    int curLife = 1;

    bool canTakeDamage = true;
    [SerializeField] Power curPower;

    public Power CurPower{get {return curPower;}}
    void Start()
    {
        allColliders = gameObject.GetComponents<Collider2D>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider2D>();
        movementScript = gameObject.GetComponent<MovementScript>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }
    public void TakenDamage()
    {
        if(!canTakeDamage) return;

        if (curPower.previousPower!=null){
            
            SetPower(curPower.previousPower);
            canTakeDamage = false;
            return; 
        }
        Die();
        
    }
    
    void Update()
    {
        if (!canTakeDamage)
        {
            DowngradePowerBlink();
        }
    }
    
    void DowngradePowerBlink()
    { 
        curBlinkingDuration += Time.deltaTime;
        if(curBlinkingDuration>=blinkingDuration)
        {
            curBlinkingDuration = 0;
            spriteRenderer.enabled = !spriteRenderer.enabled;
        }

        curBlinkingTime +=Time.deltaTime;
        if(curBlinkingTime>=totalBlinkingTime)
        { 
            canTakeDamage = true;
            spriteRenderer.enabled = true;
        }
    }
    void Die()
    {
        rb.angularVelocity = 0;
        rb.linearVelocityX = 0;
        foreach(Collider2D collider in allColliders)
        {
            collider.enabled = false;
        }
        movementScript.CanMovement = false;
        animator.enabled = false;
        spriteRenderer.sprite= deathSprite;
        rb.AddForceY(deathJumpForce, ForceMode2D.Impulse);
        
        
    }

    public void SetPower(Power power)
    {
        curPower = power;
        spriteRenderer.sprite = curPower.idleSprite;
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
        capsuleCollider.size = spriteSize;
        capsuleCollider.offset = new Vector2(0,spriteSize.y/2);
        AudioManager.instance.PlayOneShot(curPower.changeSound);
        curLife = curPower.lifes;
        animator.runtimeAnimatorController = power.animatorController;
    }
}
