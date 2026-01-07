using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BrickBreak : MonoBehaviour
{
    [SerializeField] BoxCollider2D breakerCollider;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpAnimDuration;
    [SerializeField] GameObject breakParticle;
    Vector2 originalPos;


    void Start()
    {
        originalPos = transform.position;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision.otherCollider == breakerCollider)
        {
            Power power = collision.gameObject.GetComponent<PlayerDeath>().CurPower;
            if (power.previousPower == null)
            {
                transform.DOMoveY(transform.position.y+jumpForce,jumpAnimDuration).OnComplete(()=>{
                transform.DOMoveY(originalPos.y,jumpAnimDuration);
                });
                return;                
            }
            Destroy(gameObject);
            Instantiate(breakParticle,transform.position,transform.rotation);
        }
    }
}
