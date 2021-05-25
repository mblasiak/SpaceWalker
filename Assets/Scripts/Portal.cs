using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {
    public Bar oxygenBar;
    public Bar healthBar;
    public StarCounter starCounter;
    private bool playerInside = false;
    public int starsRequired;

    void Update() {
        if (playerInside && Input.GetButtonDown("Teleport") && starCounter.GetStars() == starsRequired) {
            SavePlayerState();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
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
    void SavePlayerState() {
        PlayerPrefs.SetFloat("health", healthBar.GetLevel());
        PlayerPrefs.SetFloat("oxygen", oxygenBar.GetLevel());
        PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.Save();
    }
}