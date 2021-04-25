using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour {
    
    void Start() {
        Text title = GameObject.Find("Title").GetComponent<Text>();
        if (PlayerPrefs.HasKey("failure")) {
            title.text = "GAME OVER";
        } else {
            title.text = "VICTORY";
        }
    }

    public void playAgain() {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Level 1");
    }
}
