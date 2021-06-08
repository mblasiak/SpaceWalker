using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBubble : MonoBehaviour
{
    public OxygenBar oxygenBar;
    public float drainSpeed;

    private SpriteRenderer renderer;
    private bool playerInside = false;

    private Collider2D colider;

    void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>();
        colider = this.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    void Update()
    {
        if (playerInside && renderer.color.a > 0)
        {
            Color color = renderer.color;
            color.a -= Time.deltaTime * drainSpeed;
            renderer.color = color;
            oxygenBar.IncreaseOxygenLevel();
            var currentLengthToBottom = renderer.bounds.extents.y;
            transform.localScale = transform.localScale - Vector3.one * (Time.deltaTime * drainSpeed * 1f);
            var verticalOffset = currentLengthToBottom - renderer.bounds.extents.y;
            transform.position = new Vector3(transform.position.x, transform.position.y - verticalOffset, transform.position.z);
        }
    }
}