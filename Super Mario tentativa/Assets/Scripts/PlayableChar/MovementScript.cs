using System;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] AudioClip jumpSound;
    Renderer rd;
    Rigidbody2D rb;

    Collider2D cd;

    Camera mainCamera;

    float moveInput;
    bool JumpInput;

    public bool alreadyJumping = false;

    public bool CanMovement=true;

    AudioSource audioSource;
    

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        rd = gameObject.GetComponent<Renderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        cd = gameObject.GetComponent<Collider2D>();
        mainCamera = Camera.main;
    }
    void Update()
    {
        if (CanMovement)
        {
            HandleInput();
        }
    }
    void FixedUpdate()
    {
        if (CanMovement)
        {
            Move();
            Jump();
        }
    }
    void LateUpdate()
    {
        ClampPosition();
    }

    void HandleInput()
    {
        moveInput = Input.GetAxis("Horizontal");
        int xMove = 0;
        if (moveInput > 0)
        {
            transform.localRotation = Quaternion.Euler(0,180,0);
            xMove = 1;
        }
        else if (moveInput < 0)
        {
            transform.localRotation = Quaternion.Euler(0,0,0);
            xMove = 1;
        }
        animator.SetInteger("xMove", xMove);
        if (Input.GetKeyDown(KeyCode.Space)) JumpInput = true;

    }
    void ClampPosition()
    {
        float halfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float halfPlayerWidth = cd.bounds.extents.x; 

        float minX = mainCamera.transform.position.x - halfWidth + halfPlayerWidth;
        float maxX = mainCamera.transform.position.x + halfWidth - halfPlayerWidth;

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        transform.position = clampedPosition;
    }
    void Move()
    {
        
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocityY);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        CheckIfCanJump(collision.gameObject.tag);
    }
    void CheckIfCanJump(string tag)
    {
        if (tag == "Ground")
        {
            alreadyJumping = false;
        }
    }
    void Jump()
    {
        if (JumpInput && !alreadyJumping)
        {   
            audioSource.PlayOneShot(jumpSound);
            alreadyJumping = true;
            JumpInput = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
