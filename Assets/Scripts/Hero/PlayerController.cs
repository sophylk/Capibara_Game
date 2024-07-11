using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coolscript : MonoBehaviour
{
    private BoxCollider2D hitBox;
    private BoxCollider2D Fire_spell;

    private float horizontal;
    private float speed = 3;
    private float speedwalk = 3;
    private float speedrun = 8;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    [SerializeField] private TrailRenderer tr;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    [SerializeField] private Animator animator;


    private bool isDashing = false;
    private bool canDash = true;
    private float dashSpeed = 20f;
    private float dashDuration = 0.2f;
    private float dashCooldown = 1f;

    public float damage;
    public float spelldamage;

    private void Start()
    {

        hitBox = transform.Find("hitBox").GetComponent<BoxCollider2D>();
        Fire_spell = transform.Find("Fire_spell").GetComponent<BoxCollider2D>();
    }


    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0)) // Attack on Mouse Left Button press.
        {
            animator.SetBool("Attack", true);
            Invoke("ActivateHitbox", 0.2f); // Activate hitbox after 0.2 seconds.
            Invoke("DeactivateHitbox", 0.4f); // Deactivate hitbox after 0.4 seconds.
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0)) // Attack on Space key press.
        {
            animator.SetBool("Attack", false);

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("Spell", true);
            Invoke("ActivateSpellHitbox", 0.2f);
            Invoke("DeactivateSpellHitbox", 0.4f);
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            animator.SetBool("Spell", false);
        }


        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            animator.SetBool("Jump", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            animator.SetBool("Jump", false);
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        WallSlide();
        WallJump();

        if (!isWallJumping)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.E))
        {
            if (canDash)
            {
                StartCoroutine(Dash());
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("Run", true);
            animator.SetBool("Walk", false);

            speed = speedrun;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Run", false);
            animator.SetBool("Walk", true);

            speed = speedwalk;
        }

        bool isWalk = Mathf.Abs(horizontal) > 0.1 && !Input.GetKey(KeyCode.LeftShift);
        animator.SetBool("Walk", isWalk);


    }

    private void FixedUpdate()
    {
        if (!isWallJumping && !isDashing)
        {

            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    private bool IsGrounded()
    {

        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            animator.SetBool("Jump", true);
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }

        if (Input.GetButtonUp("Jump"))
        {
            animator.SetBool("Jump", false);
        }

    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(horizontal * dashSpeed, 0f);

        yield return new WaitForSeconds(dashDuration);

        rb.gravityScale = originalGravity;
        isDashing = false;
        speed = speedwalk;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    void ActivateHitbox()
    {
        hitBox.gameObject.SetActive(true);
    }

    void DeactivateHitbox()
    {
        hitBox.gameObject.SetActive(false);
    }

    void ActivateSpellHitbox()
    {
        Fire_spell.gameObject.SetActive(true);
    }

    void DeactivateSpellHitbox()
    {
        Fire_spell.gameObject.SetActive(false);
    }


}