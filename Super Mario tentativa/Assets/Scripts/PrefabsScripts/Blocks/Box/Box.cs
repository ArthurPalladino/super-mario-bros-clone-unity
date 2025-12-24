using System.Collections;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
public class Box : MonoBehaviour
{
    //inicialmente apenas a moeda sera criada
    //no futuro adicionar outros itens
    //TODO fazer o prefab ser dinamico de acordo com o item a ser instanciado
    [SerializeField] GameObject prefab;
    [SerializeField] Sprite brokenSprite;
    [SerializeField] float jumpForce;
    [SerializeField] float breakAnimDuration;

    [SerializeField] BoxCollider2D bottomCollider;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    
    private bool alreadyBreak = false;

    private Vector3 originalPos;

    //[SerializeField] BoxItens item;
    void Start()
    {
        originalPos = gameObject.transform.position;
        //animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (alreadyBreak) return;

        if (collision.gameObject.name == "Player" && collision.otherCollider == bottomCollider)
        {
            alreadyBreak = true;
            SelfActivate();
        }
    }

    void SelfActivate()
    {
        Vector3 instantiatePos = new Vector3(transform.position.x,transform.position.y+1);
        Instantiate(prefab,position:instantiatePos, Quaternion.identity);
        BreakAnimation();
    }

    void BreakAnimation()
    {
        transform.DOMoveY(transform.position.y+jumpForce,breakAnimDuration).OnComplete(()=>{
            spriteRenderer.sprite = brokenSprite;
            transform.DOMoveY(originalPos.y,breakAnimDuration);
            });
    }
}
