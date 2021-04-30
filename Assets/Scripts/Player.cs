using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class Player : MonoBehaviour {
    public Rigidbody2D rigidBody;
    public SpriteRenderer renderer;
    public LayerMask groundLayer;
    public OxygenBar oxygenBar;
    public HealthBar healthBar;
    public Text starCounter;
    
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;

    public float walkOxygenUsage;
    public float jumpOxygenUsage;
    public float runOxygenUsage;
    public Animator animator;
    float horizonatalMovement;
	List<string> enteredColliders = new List<string>();
    private int collectedStars = 0;
    
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Collectable")) {
            Destroy(collider.gameObject);
            collectedStars += 1;
            starCounter.text = collectedStars.ToString();;
        }
        else if (collider.CompareTag("Portal")) {
            enteredColliders.Add(collider.tag);
        }
        else if (collider.CompareTag("Portal") && collectedStars == 4) {
            SavePlayerState();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
	private void OnTriggerExit2D(Collider2D collider) {
		if (collider.CompareTag("Portal")) {
            enteredColliders.Remove(collider.tag);
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
        
		if (enteredColliders.Contains("Portal") && collectedStars == 4 && Input.GetButtonDown("Teleport")) {
			SavePlayerState();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

    void SavePlayerState() {
        PlayerPrefs.SetFloat("health", healthBar.GetHealthLevel());
        PlayerPrefs.SetFloat("oxygen", oxygenBar.GetOxygenLevel());
		PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex + 1);
		PlayerPrefs.Save();
    }
}
