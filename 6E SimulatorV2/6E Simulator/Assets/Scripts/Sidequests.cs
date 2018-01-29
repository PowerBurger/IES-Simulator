using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sidequests : MonoBehaviour
{
    public int ACounterStrikeDone;
    public int AngryBetaTesterDone = 0;
    public Text area;
    public int speed;
    public bool isMoving;
    public GameObject Complete;
    public Text CompleteText;
    public GameObject sidequestText;
    public PauseMenu pauseMenu;
    public int BN;
    public float punchTimer;
    public int FoxDone;
    public int MilkDone;
    public int LaptopsDone;

    void Start ()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        FoxDone = PlayerPrefs.GetInt("FoxDone");
        MilkDone = PlayerPrefs.GetInt("MilkDone");
        LaptopsDone = PlayerPrefs.GetInt("LaptopsDone");
        BN = PlayerPrefs.GetInt("BN");
        AngryBetaTesterDone = PlayerPrefs.GetInt("AngryBetaTesterDone");
    }
	
	
	void Update ()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        
        if(punchTimer > 0)
        {
            punchTimer -= Time.deltaTime;
        }   
        
        if(BN == 3)
        {
            BN = 0;
            PlayerPrefs.SetInt("BN", BN);
            Application.LoadLevel("Detension");
        }   
    }

    //0 is not activated, 1 is activated and 2 is activated and comleted.
    public void ACounterStrike(bool complete)
    {
        if (ACounterStrikeDone == 0 && !complete)
        {
            area = GetComponent<Text>();
            area.text = "A COUNTER STRIKE";            
            ACounterStrikeDone = 1;
            transform.position = new Vector2(-431.4982f, Screen.height -90);
            Complete.SetActive(false);
            sidequestText.SetActive(true);
        }

        if (ACounterStrikeDone == 1 && complete)
        {
            ACounterStrikeDone = 2;
            Complete.SetActive(true);
            area = GetComponent<Text>();
            area.text = "A COUNTER STRIKE";
            transform.position = new Vector2(-431.4982f, Screen.height - 90);
            sidequestText.SetActive(true);
        }
    }

    public void AngryBetaTester(bool complete)
    {
        if (AngryBetaTesterDone == 0 && !complete)
        {
            area = GetComponent<Text>();
            area.text = "BETA TESTING GONE WRONG";
            AngryBetaTesterDone = 1;
            PlayerPrefs.SetInt("AngryBetaTesterDone", AngryBetaTesterDone);
            transform.position = new Vector2(-431.4982f, Screen.height - 90);
            Complete.SetActive(false);
            sidequestText.SetActive(true);
        }

        if (AngryBetaTesterDone == 1 && complete)
        {
            AngryBetaTesterDone = 2;
            PlayerPrefs.SetInt("AngryBetaTesterDone", AngryBetaTesterDone);
            Complete.SetActive(true);
            area = GetComponent<Text>();
            area.text = "BETA TESTING GONE WRONG";
            transform.position = new Vector2(-431.4982f, Screen.height - 90);
            sidequestText.SetActive(true);
            CompleteText.text = "complete";
        }
    }

    public void AddBN(int howMany)
    {
        if (punchTimer <= 0)
        {
            BN = BN + howMany;
            PlayerPrefs.SetInt("BN", BN);
            area = GetComponent<Text>();
            area.text = "BEHAVIOUR NOTICE";
            transform.position = new Vector2(-307.3315f, Screen.height - 60);
            sidequestText.SetActive(false);
            punchTimer = 4;
        }

        if(BN == 1)
        {
            CompleteText.text = "o - -";
            Complete.SetActive(true);
        }

        if (BN == 2)
        {
            CompleteText.text = "o o -";
            Complete.SetActive(true);
        }

        if (BN == 3)
        {
            CompleteText.text = "o o o";
            Complete.SetActive(true);
        }
    }

    public void Fox(bool complete)
    {
        if (FoxDone == 0 && !complete)
        {
            area = GetComponent<Text>();
            area.text = "mr fox";
            FoxDone = 1;
            transform.position = new Vector2(-431.4982f, Screen.height - 90);
            Complete.SetActive(false);
            sidequestText.SetActive(true);
            PlayerPrefs.SetInt("FoxDone", FoxDone);
        }

        if (FoxDone == 1 && complete)
        {
            FoxDone = 2;
            Complete.SetActive(true);
            area = GetComponent<Text>();
            area.text = "mr fox";
            transform.position = new Vector2(-431.4982f, Screen.height - 90);
            sidequestText.SetActive(true);
            PlayerPrefs.SetInt("FoxDone", FoxDone);
            CompleteText.text = "complete";
        }
    }

    public void Laptops(bool complete)
    {
        if (LaptopsDone == 0 && !complete)
        {
            area = GetComponent<Text>();
            area.text = "the people's laptops";
            LaptopsDone = 1;
            transform.position = new Vector2(-431.4982f, Screen.height - 90);
            Complete.SetActive(false);
            sidequestText.SetActive(true);
            PlayerPrefs.SetInt("LaptopsDone", LaptopsDone);
        }

        if (LaptopsDone == 1 && complete)
        {
            LaptopsDone = 2;
            Complete.SetActive(true);
            area = GetComponent<Text>();
            area.text = "the people's laptops";
            transform.position = new Vector2(-431.4982f, Screen.height - 90);
            sidequestText.SetActive(true);
            PlayerPrefs.SetInt("LaptopsDone", LaptopsDone);
            CompleteText.text = "complete";
        }
    }

    public void Milk(bool complete)
    {
        if (MilkDone == 0 && !complete)
        {
            area = GetComponent<Text>();
            area.text = "that holy milk";
            MilkDone = 1;
            transform.position = new Vector2(-431.4982f, Screen.height - 90);
            Complete.SetActive(false);
            sidequestText.SetActive(true);
            PlayerPrefs.SetInt("MilkDone", MilkDone);
        }

        if (MilkDone == 1 && complete)
        {
            MilkDone = 2;
            Complete.SetActive(true);
            area = GetComponent<Text>();
            area.text = "that holy milk";
            transform.position = new Vector2(-431.4982f, Screen.height - 90);
            sidequestText.SetActive(true);
            PlayerPrefs.SetInt("MilkDone", MilkDone);
            CompleteText.text = "complete";
        }
    }
}

