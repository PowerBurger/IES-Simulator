using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MrMather : MonoBehaviour {

    public GameObject text1;
    public GameObject text2;
    public float TimeLeft = 4;
    private bool TimerStarted;

    void Start()
    {
        if (Application.loadedLevelName == "D5")
        { 
            FirstPersonController.canMove = true;
        }
		
	}

	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            text1.SetActive(false);
            text2.SetActive(true);
            TimerStarted = true;
        }

        if(TimerStarted && TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
        }

        if(TimeLeft <= 0)
        {
            PlayerPrefs.SetInt("MrMatherDone", 1);
            PlayerPrefs.SetInt("AppleAward", PlayerPrefs.GetInt("AppleAward") + 1);
            Application.LoadLevel("Schoolyard");
        }
	}
}
