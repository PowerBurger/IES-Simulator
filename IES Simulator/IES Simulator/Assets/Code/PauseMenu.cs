//*******************************************************************************
//																							
//							Written by Grady Featherstone and modded by someone (° ͜ʖ͡°)								
//										� Copyright 2011										
//*******************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Font pauseMenuFont;
    bool pauseEnabled = false;
    public GameObject talk;
    public GameObject click;
    public GameObject respectText;
    public GameObject BNText;
    public GameObject Panel;
    public Text respectText2;
    public Text BNText2;
    public static int appleAward;
    public float respectTimer = 0;
    private Sidequests sidequests;
    public Activator activator;



    void Start()
    {
        sidequests = FindObjectOfType<Sidequests>();
        activator = FindObjectOfType<Activator>();

        pauseEnabled = false;
        Time.timeScale = 1;
        AudioListener.volume = 1;
        Cursor.visible = false;
        respectText.SetActive(false);
        BNText.SetActive(false);
        appleAward = PlayerPrefs.GetInt("AppleAward");
    }

    void Update()
    {      
        if(Application.platform == RuntimePlatform.Android)
        {
            Screen.lockCursor = false;
            Cursor.visible = true;
        }

        //check if game is already paused		
        if (Screen.lockCursor == true && Application.platform != RuntimePlatform.WebGLPlayer && Application.platform != RuntimePlatform.Android && activator.isHel == false)
        {
                //unpause the game
                pauseEnabled = false;
                Time.timeScale = 1;
                AudioListener.volume = 1;
                Cursor.visible = false;
                respectText.SetActive(false);
                BNText.SetActive(false);
        }

        //else if game isn't paused, then pause it
        if(Screen.lockCursor == false && Panel.activeSelf == false && Application.platform != RuntimePlatform.WebGLPlayer && Application.platform != RuntimePlatform.Android && activator.isHel == false)  
        {
            pauseEnabled = true;
            AudioListener.volume = 0;
            Time.timeScale = 0;
            Cursor.visible = true;
            respectText.SetActive(true);
            BNText.SetActive(true);
        }
        

        if(respectTimer <= 0)
        {
            respectText2.text = "Apple award    " + appleAward.ToString();
        }

        if(respectTimer > 0)
        {
            respectTimer = respectTimer - 1 * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.P) && Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.T))
        {
            appleAward += 1;
        }
        
        BNText2.text = "BEHAVIOUR NOTICE    " + sidequests.BN.ToString();
        PlayerPrefs.SetInt("AppleAward", appleAward);
    }


public bool showGraphicsDropDown = false;

void OnGUI()
{

    GUI.skin.box.font = pauseMenuFont;
    GUI.skin.button.font = pauseMenuFont;

    if (pauseEnabled == true)
    {

        //Make a background box
        //GUI.Box(Rect(Screen.width /2 - 100,Screen.height /2 - 100,250,200), "6E Simulator");

        //Unpause
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 250, 50), "Let's get back to it"))
        {
            pauseEnabled = false;
            Time.timeScale = 1;
            AudioListener.volume = 1;
            Cursor.visible = false;
        }




        //Create the Graphics settings buttons, these won't show automatically, they will be called when
        //the user clicks on the "Change Graphics Quality" Button, and then dissapear when they click
        //on it again....
        if (showGraphicsDropDown == true)
        {
            if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2, 250, 50), "Fastest"))
            {
                QualitySettings.currentLevel = QualityLevel.Fastest;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 + 50, 250, 50), "Fast"))
            {
                QualitySettings.currentLevel = QualityLevel.Fast;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 + 100, 250, 50), "Simple"))
            {
                QualitySettings.currentLevel = QualityLevel.Simple;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 + 150, 250, 50), "Good"))
            {
                QualitySettings.currentLevel = QualityLevel.Good;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 + 200, 250, 50), "Beautiful"))
            {
                QualitySettings.currentLevel = QualityLevel.Beautiful;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 + 250, 250, 50), "Fantastic"))
            {
                QualitySettings.currentLevel = QualityLevel.Fantastic;
            }

            if (Input.GetKeyDown("escape"))
            {
                showGraphicsDropDown = false;
            }
        }

        //Make quit game button
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 25, 250, 50), "I'm outa here"))
        {

            Application.LoadLevel("TitleScreen");
        }
    }
}

    public void ShowGfx()
    {
        showGraphicsDropDown = true;
    }

    public void HideGfx()
    {
        showGraphicsDropDown = false;
    }
}