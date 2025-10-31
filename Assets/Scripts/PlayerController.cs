using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed = 5f;
    public float jumpForce = 10f;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            rigidBody.linearVelocity = 
                new Vector2(Input.GetAxis("Horizontal") * speed, 
                    rigidBody.linearVelocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForceY(jumpForce);
        }
    }
}
