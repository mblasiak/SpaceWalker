using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Slider slider;
    
    void Start() {
        if (PlayerPrefs.HasKey("health")) {
			slider.value = PlayerPrefs.GetFloat("health");
		} else {
			slider.value = slider.maxValue;
		}
    }

    public void DecreaseHealth(float value) {
        slider.value -= value;
        if (slider.value <= 0.0f) {
            Debug.Log("You died");
        }
    }

	public float getHealthLevel() {
		return slider.value;
	}
}