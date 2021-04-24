using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Rigidbody2D rb;
    public SpriteRenderer renderer;
    public LayerMask groundLayer;
    public OxygenBar oxygenBar;
    public HealthBar healthBar;
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;

    public float walkOxygenUsage;
    public float jumpOxygenUsage;
    public float runOxygenUsage;

    public Animator animator;

    float horizonatalMovement;

    void Update() {
        Move();

        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            oxygenBar.usageMultiplier = jumpOxygenUsage;
            Jump();
        }

        //used for testing -> to be removed
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            ReceiveDamage();
        }

        if (oxygenBar.slider.value == 0) {
            healthBar.DecreaseHealth(Time.deltaTime);
        }
    }

    void Move() {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        setSpriteDirection(horizontalMovement);

        animator.SetFloat("walkSpeed", Mathf.Abs(horizontalMovement));

        if (Input.GetKey(KeyCode.LeftShift)) {
            horizontalMovement *= runSpeed ;
            oxygenBar.usageMultiplier = runOxygenUsage;
        } else {
            horizontalMovement *= walkSpeed;
            oxygenBar.usageMultiplier = walkOxygenUsage;
        }

        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y); 
    }

    bool IsGrounded() {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 3.8f;
        
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null) {
            return true;
        }
        return false;
    }

    void Jump() {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void ReceiveDamage() {
        healthBar.DecreaseHealth(10.0f);
    }

    void setSpriteDirection(float horizontalMovement) {
        if (horizontalMovement < 0) {
            renderer.flipX = true;
        }
        else if (horizontalMovement > 0) {
            renderer.flipX = false;
        }
    }
}
