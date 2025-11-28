using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    
    public Transform wallDetector;
    public LayerMask wallDetectorLayer;
    
    public Vector2 velocity = new Vector2(5, 0); //(x,y)
    public bool faceRight = true;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Physics2D.Linecast(transform.position + Vector3.up, wallDetector.position, wallDetectorLayer))
        {
            faceRight = !faceRight;
            transform.localScale = new Vector3((faceRight ? 1 : -1), 1, 1);
            
        }
            
        if (faceRight)
        {
            rigidBody.linearVelocity = velocity;
        }
        else
        {
            rigidBody.linearVelocity = -velocity;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color =  Color.darkGreen;
        Gizmos.DrawLine(transform.position  + Vector3.up, wallDetector.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Jump();
            Destroy(gameObject);
        }
    }
}
