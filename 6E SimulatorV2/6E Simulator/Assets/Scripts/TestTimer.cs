using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTimer : MonoBehaviour {

    public float seconds;
    public float minutes;

    public GameObject testText;

	// Use this for initialization
	void Start ()
    {
		if(PlayerPrefs.GetInt("DoneTest1") == 1)
        {
            testText.SetActive(false);
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (seconds >= -1)
        {
            seconds -= Time.deltaTime;
        }

        if (Mathf.Round(seconds) == -1)
        {
            minutes -= 1;
            seconds = 59;
        }

        if(GetComponent<Text>().text == "0:0" && PlayerPrefs.GetInt("DoneTest1") == 0)
        {
            Application.LoadLevel("Assesment");
        }
        GetComponent<Text>().text = minutes.ToString() + ":" + Mathf.Round(seconds).ToString();
	}
}
