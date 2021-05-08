using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCounter : MonoBehaviour {
    private int starsCollected = 0;
    private Text starCounterText;

    void Start() {
        starCounterText = this.GetComponent<Text>();
        starCounterText.text = starsCollected.ToString();
    }

    public void Increase() {
        starsCollected++;
        starCounterText.text = starsCollected.ToString();
    }

    public int GetStars() {
        return starsCollected;
    }
}
