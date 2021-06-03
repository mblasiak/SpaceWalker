using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class Player : MonoBehaviour {
    private static float colectStartDist=2f;
    public Rigidbody2D rigidBody;
    public SpriteRenderer renderer;
    public LayerMask groundLayer;
    public OxygenBar oxygenBar;
    public HealthBar healthBar;
    public StarCounter starCounter;
    
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;

    public float walkOxygenUsage;
    public float jumpOxygenUsage;
    public float runOxygenUsage;
    public Animator animator;

    float horizonatalMovement;
    public static String heroSoundPlayerName = "heroPlayer";
    void Start() {
        SoundLocator.registerPlayer(heroSoundPlayerName,new HeroSoundPlayer(GetComponent<AudioSource>()));
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Collectable") &&
            (collider.transform.position-transform.position).ProjectOntoPlane(Vector3.forward).magnitude<colectStartDist) {
            Destroy(collider.gameObject);
            starCounter.Increase();
        }
    }

    void Update() {
        Move();
		Jump();

        if (IsGrounded()) {
            animator.SetBool("isJumping",false);
        } else {
            animator.SetBool("isJumping",true);
        }

        //used for testing -> to be removed
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            ReceiveDamage();
        }

        if (oxygenBar.GetLevel() == 0) {
            healthBar.DecreaseHealth(Time.deltaTime);
        }
    }
    
    void Move() {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        SetSpriteDirection(horizontalMovement);

        animator.SetFloat("walkSpeed", Mathf.Abs(horizontalMovement));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            horizontalMovement *= runSpeed ;
            animator.SetFloat("walkSpeed", Mathf.Abs(horizontalMovement));
            oxygenBar.usageMultiplier = runOxygenUsage;
        } else {
            horizontalMovement *= walkSpeed;
            oxygenBar.usageMultiplier = walkOxygenUsage;
        }

        rigidBody.velocity = new Vector2(horizontalMovement, rigidBody.velocity.y); 
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
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            SoundLocator.getPlayer(heroSoundPlayerName).playSound("jump_eq");
            SoundLocator.getPlayer(heroSoundPlayerName).playSound("jump_fat");
            oxygenBar.usageMultiplier = jumpOxygenUsage;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }
    }
 
    void ReceiveDamage() {
        healthBar.DecreaseHealth(10.0f);
    }

    void SetSpriteDirection(float horizontalMovement) {
        if (horizontalMovement < 0) {
            renderer.flipX = true;
        }
        else if (horizontalMovement > 0) {
            renderer.flipX = false;
        }
    }
}
