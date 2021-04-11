using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Rigidbody2D rb;
    public LayerMask groundLayer;
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;

    float horizonatalMovement;

    void Update() {
        Move();

        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            Jump();
        }
    }

    void Move() {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift)) {
            horizontalMovement *= runSpeed ;
        } else {
            horizontalMovement *= walkSpeed;
        }

        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y); 
    }

    bool IsGrounded() {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;
        
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null) {
            return true;
        }
        return false;
    }

    void Jump() {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
