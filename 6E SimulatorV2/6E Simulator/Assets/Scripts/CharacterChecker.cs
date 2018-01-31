﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChecker : MonoBehaviour
{
    public Text lines;
    public GameObject MrFaxen;
    public Sidequests sidequests;
    public TextBoxManager textBoxManager;
    public PauseMenu pauseMenu;
    public TextAsset AngryHampus;
    public TextAsset Intro;
    public GameObject HildeZone;
    public Sprite MrFaxenNameTag;
    public Sprite MrFoxNameTag;
    
    void Start ()
    {
        sidequests = FindObjectOfType<Sidequests>();
        textBoxManager = FindObjectOfType<TextBoxManager>();
        pauseMenu = FindObjectOfType<PauseMenu>();

        if (PlayerPrefs.GetInt("Intro") == 0)
        {
            textBoxManager.ReloadScript(Intro);
            textBoxManager.currentLine = 1;
            textBoxManager.endAtLine = 4;
            textBoxManager.EnableTextBox();
        }
    }
	

	void Update ()
    {
        lines = GetComponent<Text>();

        if (lines.text.Substring(0,3).ToLower() == "so," )
        {
            sidequests.ACounterStrike(false);
        }

        if (lines.text.Substring(0, 2).ToLower() == "no")
        {
            sidequests.ACounterStrike(true);
        }

        if (lines.text.Substring(0, 7).ToLower() == "go shou")
        {
            sidequests.AngryBetaTester(false);
        }

        if (lines.text.Substring(0, 9).ToLower() == "at least ")
        {
            sidequests.AngryBetaTester(true);
        }

        if (lines.text.Substring(0, 8).ToLower() == "okay. 7f")
        {
            textBoxManager.currentLine = 0;
            Application.LoadLevel("Matsal");
        }

        if (lines.text.Substring(0, 9).ToLower() == "at least,")
        {
            sidequests.Fox(false);
        }

        if (lines.text.Substring(0, 11).ToLower() == "thanks mate")
        {
            sidequests.Milk(false);
        }

        if (lines.text.Substring(0, 20).ToLower() == "this is not holiday!")
        {
            sidequests.Laptops(false);
        }

        if (lines.text.Substring(0, 25).ToLower() == "holiday means apple award")
        {
            sidequests.Laptops(true);
        }

        if (lines.text.Substring(0, 13).ToLower() == "okay then...f")
        {
            Application.LoadLevel("D5");
        }

        if (lines.text.Substring(0, 12).ToLower() == "may the fo..")
        {
            PlayerPrefs.SetInt("BasementKey", 1);
        }

        if (lines.text.Substring(0, 5).ToLower() == "waaaa")
        {
            if (MrFaxen.GetComponent<SpriteRenderer>().sprite !=  MrFoxNameTag)
            {
                PlayerPrefs.SetInt("AppleAward", PlayerPrefs.GetInt("AppleAward") + 1);
                PauseMenu.appleAward = PlayerPrefs.GetInt("AppleAward");
            }

            MrFaxen.GetComponent<SpriteRenderer>().sprite = MrFoxNameTag;            
            sidequests.Fox(true);
        }

        if (lines.text.Substring(0, 5).ToLower() == "shchh")
        {
            sidequests.Milk(true);
            PlayerPrefs.SetInt("Cookie", 1);
        }

        if (lines.text.Substring(0, 7).ToLower() == "hey...." && sidequests.AngryBetaTesterDone == 1)
        {
            textBoxManager.ReloadScript(AngryHampus);
            textBoxManager.currentLine = 1;
            textBoxManager.endAtLine = 10;
            textBoxManager.EnableTextBox();
            HildeZone.SetActive(false);
            PlayerPrefs.SetInt("HasJumpyBoots", 1);
        }
    }
}

