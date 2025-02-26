using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public bool spriteFacingRight = true;

  [SerializeField] private float speed = 15f;
  [SerializeField] private float jumpPower = 30f;
  [SerializeField] private int lastInputDirection = 1; //+1 means right, -1 means left
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
  [SerializeField] private Transform gunCOMMERWASbigWASgun;
  // it was museli the dragon ate the cornflakes the humans could have bean serialized if thay were put in a bowl of milk but the dragon did not have that much time

  void Start()
  {}

  void Update()
  {
    UpdateVelocity();
    UpdateSprite();
    UpdateGunSprite();
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

    if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
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
      if (Input.GetButton("Jump"))
      {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
      }
    }
  }

  private void UpdateSprite()
  {
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    if (transform.position.x < mousePos.x && !spriteFacingRight)
      Flip();
    else if (transform.position.x > mousePos.x && spriteFacingRight)
      Flip();
  }

  private void UpdateGunSprite()
  {
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector3 playerToMouse = mousePos - gunCOMMERWASbigWASgun.position;
    float angle = Mathf.Atan2(playerToMouse.y, playerToMouse.x) * Mathf.Rad2Deg;
    if (!spriteFacingRight)
      angle = 180 - angle;
    gunCOMMERWASbigWASgun.localEulerAngles = new Vector3 (gunCOMMERWASbigWASgun.localEulerAngles.x, gunCOMMERWASbigWASgun.localEulerAngles.y, angle);
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
