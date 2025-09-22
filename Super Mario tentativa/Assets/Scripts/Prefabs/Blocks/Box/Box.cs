using UnityEngine;

public class Box : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody2D;

    private Sprite sprite;
    private bool alreadyBreak = false;

    [SerializeField] BoxItens item;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<Sprite>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (alreadyBreak) return;

        if (collision.gameObject.name == "Player")
        {
            alreadyBreak = true;
            SelfActivate();
        }
    }

    void SelfActivate()
    {
        PlayActivateAnimation();
    }

    void PlayActivateAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Destruct");
        }
    }
}
