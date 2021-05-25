using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : Bar {    
    public void DecreaseHealth(float value) {
        Decrease(value);
        if (GetLevel() <= 0.0f) {
			      PlayerPrefs.SetInt("failure", 1);
			      PlayerPrefs.Save();
            SceneManager.LoadScene("End Menu");
        }
    }

	override protected string GetResourceName() {
		return "health";
	}
}