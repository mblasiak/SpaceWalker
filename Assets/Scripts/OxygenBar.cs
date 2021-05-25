using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : Bar {
	public float speedIncrease;
    public float usageMultiplier;

    void Update() {
	    Decrease(Time.deltaTime * usageMultiplier);
    }

	public void IncreaseOxygenLevel() {
		Increase(Time.deltaTime * usageMultiplier * speedIncrease);
	}
	
	override protected string GetResourceName() {
		return "oxygen";
	}
}
