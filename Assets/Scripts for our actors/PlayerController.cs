using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private float speed = 15f;
  [SerializeField] private float jumpPower = 30f;
  [SerializeField] private int lastInputDirection = 1; //+1 means right, -1 means left
  [SerializeField] private bool spriteFacingRight = true;
  // Dashing variables:
  [SerializeField] private bool canDash = true;
  [SerializeField] private bool isDashing = false;
  [SerializeField] private float dashingPower = 30f;
  [SerializeField] private float dashingTime = 0.2f;
  [SerializeField] private float dashingCooldown = 1f;

  [SerializeField] private Rigidbody2D rb;
  [SerializeField] private Transform groundCheck;
  [SerializeField] private LayerMask groundLayer;
  [SerializeField] private TrailRenderer tr;

  void Start()
  {

  }

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
    float horizontalInputDirection = Input.GetAxis("Horizontal");
    if (horizontalInputDirection > 0)
      lastInputDirection = 1;
    else if (horizontalInputDirection < 0)
      lastInputDirection = -1;

    if (Input.GetKeyDown(KeyCode.Z) && canDash)
    {
      StartCoroutine(Dash());
    }

    if (isDashing)
    {
      return;
    }
    
    rb.velocity = new Vector2(horizontalInputDirection * speed, rb.velocity.y);

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
    if (lastInputDirection > 0 && !spriteFacingRight)
      Flip();
    else if (lastInputDirection < 0 && spriteFacingRight)
      Flip();
  }

  private void Flip()
  {
    transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    spriteFacingRight = !spriteFacingRight;
  }

  private IEnumerator Dash()
  {
    canDash = false;
    isDashing = true;
    float originalGravity = rb.gravityScale; // Save gravity to be restored later
    rb.gravityScale = 0f;
    rb.velocity = new Vector2(lastInputDirection * dashingPower, 0f);
    tr.emitting = true;
    yield return new WaitForSeconds(dashingTime);
    tr.emitting = false;
    rb.gravityScale = originalGravity;
    isDashing = false;
    yield return new WaitForSeconds(dashingCooldown);
    canDash = true;
  }
}
