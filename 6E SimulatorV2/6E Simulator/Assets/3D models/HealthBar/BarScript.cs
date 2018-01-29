using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private Image content;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }
    
	void Start ()
    {
		
	}
	
	void Update ()
    {
        HandleBar();
	}

    //This just sets the health bar to the float fillAmount
    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = fillAmount;
        }
    }

    //Converts your Values into a scale between 0-1
    private float Map(float value, float inMin, float inMax,float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        //(80 - 0) * (1 -0) / (100 -0) + 0;       <- TEST CALCULATION
        // 80 * 1 / 100 = 0.8
    }
}
