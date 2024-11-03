using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public Rigidbody2D rb;
  public float speed = 15f;
  public float jumpPower = 30f;
  public Transform groundCheck;
  public LayerMask groundLayer;

  private bool bFacingRight = true;

    void Update()
    {
      UpdateVelocity();
      UpdateSprite();
    }

    private bool IsGrounded()
    {
      return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void UpdateVelocity()
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

    private void UpdateSprite()
    {
      if (rb.velocity.x > 0 && !bFacingRight)
        Flip();
      else if (rb.velocity.x < 0 && bFacingRight)
        Flip();
    }

    private void Flip()
    {
      transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
      bFacingRight = !bFacingRight;
    }
}
