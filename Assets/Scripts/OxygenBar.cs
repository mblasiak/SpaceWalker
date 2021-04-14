using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour {
    public Slider slider;
    public float usageMultiplier;

    void Start() {
        slider.value = slider.maxValue;
    }

    void Update() {
        if (slider.value > 0.0f) {
            slider.value -= Time.deltaTime * usageMultiplier;
        }
    }
}
