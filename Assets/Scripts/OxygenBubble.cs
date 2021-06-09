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
    private AudioSource _audioSource;

    Dictionary<string, AudioClip> clips =
        new Dictionary<string, AudioClip>();

    void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>();
        colider = this.GetComponent<Collider2D>();
        _audioSource = GetComponent<AudioSource>();
        clips.Add("buble_end", Resources.Load<AudioClip>("sounds/buble_end"));
        clips.Add("buble_no_air", Resources.Load<AudioClip>("sounds/buble_no_air"));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInside = true;
            if (renderer.color.a > 0)
            {
                _audioSource.Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInside = false;
            _audioSource.Stop();
            if (renderer.color.a > 0)
            {
                _audioSource.PlayOneShot(clips["buble_end"]);
            }
        }
    }

    void Update()
    {
        if (playerInside && renderer.color.a > 0)
        {
            Color color = renderer.color;
            color.a -= Time.deltaTime * drainSpeed;
            renderer.color = color;
            if (renderer.color.a <= 0.1f)
            {
                _audioSource.loop = false;
                _audioSource.Stop();
                _audioSource.PlayOneShot(clips["buble_end"]);
            }

            oxygenBar.IncreaseOxygenLevel();
            var currentLengthToBottom = renderer.bounds.extents.y;
            transform.localScale = transform.localScale - Vector3.one * (Time.deltaTime * drainSpeed * 1f);
            var verticalOffset = currentLengthToBottom - renderer.bounds.extents.y;
            transform.position = new Vector3(transform.position.x, transform.position.y - verticalOffset,
                transform.position.z);
        }
    }
}