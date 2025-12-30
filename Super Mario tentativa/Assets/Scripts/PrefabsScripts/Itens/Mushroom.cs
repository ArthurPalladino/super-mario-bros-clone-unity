using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] Power mushroomPower;
    void OnTriggerEnter2D(Collider2D  other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerDeath>().SetPower(mushroomPower);
            Destroy(gameObject);
        }
    }
}
