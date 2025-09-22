using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        var playerInput = Input.GetAxis("Horizontal");
        if (playerInput != 0)
        {
            Vector3 moveDirection = new Vector3(playerInput, 0, 0) * moveSpeed * Time.deltaTime;
            transform.position += moveDirection;
        }
        else
        {
            
        }
    }

    void Jump()
    {
        
    }
}
