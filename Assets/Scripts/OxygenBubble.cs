using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBubble : MonoBehaviour {

    public OxygenBar oxygenBar;
    public float drainSpeed;
    
    private SpriteRenderer renderer;
    private bool playerInside = false;

    void Start() {
        renderer = this.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            playerInside = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            playerInside = false;
        }
    }
    void Update() {
        if (playerInside && renderer.color.a > 0) {
            Color color = renderer.color;
            color.a -= Time.deltaTime * drainSpeed;
            renderer.color = color;
            oxygenBar.IncreaseOxygenLevel();
        }
    }
}
