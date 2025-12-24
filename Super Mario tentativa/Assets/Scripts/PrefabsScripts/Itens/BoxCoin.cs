using System.Collections;
using UnityEngine;

public class BoxCoin : MonoBehaviour
{
    [SerializeField] float jumpForce;
    //Animator animator;
    Rigidbody2D rb;
    

    void Start()
    {
        //animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(AnimateAndSelfDestroy());
        ScoreManager.instance.addCoin();
    }

    IEnumerator AnimateAndSelfDestroy()
    {   
        rb.AddForceY(jumpForce,ForceMode2D.Impulse);
        //animator.SetTrigger("Instantiated");
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }

}
