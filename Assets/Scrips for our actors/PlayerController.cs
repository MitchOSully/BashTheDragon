using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public Rigidbody2D rb;
  public float speed = 6f;
  public float jumpPower = 5f;
  public Transform groundCheck;
  public LayerMask groundLayer;

    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        if (IsGrounded())
        {
          //Jumping
          if (Input.GetButtonDown("Jump"))
          {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
          }
        }
    }

    private bool IsGrounded()
    {
      return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
