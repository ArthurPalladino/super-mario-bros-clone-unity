using System.Diagnostics;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] AudioClip getCoinSound;

    void OnTriggerEnter2D(Collider2D  other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScoreManager.instance.addCoin();
            AudioManager.instance.PlayOneShot(getCoinSound);
            Destroy(gameObject);
        }
    }
    
}
