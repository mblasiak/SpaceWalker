using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Slider slider;
    
    void Start() {
        slider.maxValue = 30.0f;
        slider.value = 30.0f;
    }

    public void DecreaseHealth(float value) {
        slider.value -= value;
        if (slider.value <= 0.0f) {
            Debug.Log("You died");
        }
    }
}