using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed = 5f;
    public float jumpForce = 10f;
    
    [SerializeField] private bool isGrounded = false;
    public LayerMask groundLayer;
    
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            rigidBody.linearVelocity = 
                new Vector2(Input.GetAxis("Horizontal") * speed, 
                    rigidBody.linearVelocity.y);
            
            animator.SetBool("Walking", true);
            if (rigidBody.linearVelocity.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            if (rigidBody.linearVelocity.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            
        }
        else
        {
            animator.SetBool("Walking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }
    }

    public void Jump()
    {
        rigidBody.linearVelocityY = 0;
        rigidBody.AddForceY(jumpForce);
        animator.SetTrigger("Jump");
        isGrounded = false;
    }

    void LateUpdate()
    {
        animator.SetBool("isGrounded", isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //(1<<other.gameObject.layer) & groundLayer) != 0
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }

    
}
