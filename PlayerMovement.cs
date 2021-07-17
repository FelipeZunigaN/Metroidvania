using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator myAnimator;
    private bool facingRight = true;

    public float speed = 2.0f;
    public float horizMovement;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Handles the input of physics
    private void Update()
    {   
        // La diferencia entre getaxis y el getaxisraw es que el getaxis pasa lentamente de -1 a 1 el otro es 1 o -1
        horizMovement = Input.GetAxisRaw("Horizontal");
    }

    // Handles running the physics
    private void FixedUpdate()  
    {
        rb2D.velocity = new Vector2(horizMovement * speed, rb2D.velocity.y);
        Flip(horizMovement);
        myAnimator.SetFloat("speed", Mathf.Abs(horizMovement));
    }

    private void Flip(float horizontal)
    {
        if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
