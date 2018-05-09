using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assesment : MonoBehaviour {

    private static int points = 0;
    public static string grade;
    public GameObject letter;
    private static float gradeTimer = 10;
    private static bool isGraded = false;
    public GameObject paper;
    public GameObject loading;

	void Start ()
    {
		
	}

	void Update ()
    {
        if(grade != "" && isGraded)
        {
            gradeTimer -= Time.deltaTime;
        }

        if(gradeTimer <= 0)
        {
            paper.SetActive(false);
            loading.SetActive(true);
            Application.LoadLevel("Schoolyard");
        }

        if (Application.loadedLevelName == "Assesment2")
        {
            Screen.lockCursor = false;
        }
	}

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Right()
    {
        points += 1;
    }

    public void Grade()
    {
        isGraded = true;
        PlayerPrefs.SetInt("DoneTest1", 1);

        if(points == 0)
        {
            grade = "F";
        }

        if (points == 1)
        {
            grade = "E";
        }

        if (points == 2)
        {
            grade = "C";
        }

        if (points == 3)
        {
            grade = "A";
            PlayerPrefs.SetInt("AppleAward", PlayerPrefs.GetInt("AppleAward") + 1);
        }

        letter.SetActive(true);
        letter.GetComponent<Text>().text = grade;
    }
}
