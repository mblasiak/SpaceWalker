using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Slider slider;
    
    void Start() {
        slider.maxValue = 3;
        slider.value = 3;
    }

    public void DecreaseHealth() {
        slider.value -= 1;
        if (slider.value == 0) {
            Debug.Log("You died");
        }
    }
}