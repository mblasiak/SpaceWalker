using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour {
    
    void Start() {
        Text title = GameObject.Find("Title").GetComponent<Text>();
        if (PlayerPrefs.HasKey("failure")) {
            title.text = "GAME OVER";
        } else {
            title.text = "VICTORY";
        }
    }

    public void PlayAgain() {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene(1);
    }

    public void Exit() {
        Application.Quit();
    }
}
