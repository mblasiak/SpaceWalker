using UnityEngine;
using UnityEngine.UI;

abstract public class Bar : MonoBehaviour {
    public Slider slider;
    void Start() {
        string resourceName = GetResourceName();
        if (PlayerPrefs.HasKey(resourceName)) {
            slider.value = PlayerPrefs.GetFloat(resourceName);
        } else {
            slider.value = slider.maxValue;
        }
    }

    protected void Decrease(float value) {
        if (GetLevel() > 0.0f) {
            slider.value -= value;
        }
    }

    protected void Increase(float value) {
        if (GetLevel() < slider.maxValue) {
            slider.value += value;
        }
    }

    public float GetLevel() {
        return slider.value;
    }

    protected abstract string GetResourceName();
}
