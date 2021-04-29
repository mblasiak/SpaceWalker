using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    public void StartNewGame() {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene(1);
    }

    public void Resume() {
        if (PlayerPrefs.HasKey("level")) {
            SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
        } else {
            this.StartNewGame();
        }
    }

    public void Exit() {
        Application.Quit();
    }
}
