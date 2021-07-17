using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Public Vars")]
    public float jumpForce;
    public bool grounded;
    private Rigidbody2D rb;

    [Header("Private Vars")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radOfCircle;
    [SerializeField] LayerMask whatIsGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    
    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position,radOfCircle, whatIsGround);
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(groundCheck.position, radOfCircle);
    }
}
