using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChecker : MonoBehaviour
{
    public string lines;
    public GameObject MrFaxen;
    public Sidequests sidequests;
    public DialogueManager textBoxManager;
    public PauseMenu pauseMenu;
    public TextAsset AngryHampus;
    public TextAsset Intro;
    public GameObject HildeZone;
    public Sprite MrFaxenNameTag;
    public Sprite MrFoxNameTag;
    
    void Start ()
    {
        sidequests = FindObjectOfType<Sidequests>();
        textBoxManager = FindObjectOfType<DialogueManager>();
        pauseMenu = FindObjectOfType<PauseMenu>();

        //if (PlayerPrefs.GetInt("Intro") == 0)
        //{
        //    textBoxManager.ReloadScript(Intro);
        //    textBoxManager.currentLine = 1;
        //    textBoxManager.endAtLine = 4;
        //    textBoxManager.EnableTextBox();
        //}
    }
	

	void Update ()
    {
        lines = FindObjectOfType<DialogueManager>().sentence.ToString();
        print("lines is " + lines);

        if (lines == "THANKS MATE")
        {
            sidequests.Milk(false);
        }
        //print(lines.text.Substring(0, 4).ToLower());

        if (lines == "This is not holiday!")
        {
            sidequests.Laptops(false);
        }

        if (lines.Substring(0, 25).ToLower() == "holiday means apple award")
        {
            sidequests.Laptops(true);
        }

       

        if (lines.Substring(0,3).ToLower() == "so," )
        {
            sidequests.ACounterStrike(false);
        }

        if (lines.Substring(0, 4).ToLower() == "swoo")
        {
            GameObject.Find("FPSController").transform.position = new Vector3(-277.1f, -6.23f, 2382.99f);
        }

        if (lines.Substring(0, 2).ToLower() == "no")
        {
            sidequests.ACounterStrike(true);
        }

        if (lines.Substring(0, 7).ToLower() == "go shou")
        {
            sidequests.AngryBetaTester(false);
        }

        if (lines.Substring(0, 27).ToLower() == "now, i shall chase you like")
        {
            GameObject.Find("Mr.HaagPizzeria").GetComponent<MrHaagFollowPlayer>().isMad = true;
        }

        if (lines.Substring(0, 9).ToLower() == "at least ")
        {
            sidequests.AngryBetaTester(true);
        }

        if (lines.Substring(0, 8).ToLower() == "okay. 7f")
        {
            //textBoxManager.currentLine = 0;
            Application.LoadLevel("Matsal");
        }

        if (lines.Substring(0, 9).ToLower() == "at least,")
        {
            sidequests.Fox(false);
        }
        if (lines.Substring(0, 13).ToLower() == "okay then...f")
        {
            Application.LoadLevel("D5");
        }

        if (lines.Substring(0, 12).ToLower() == "may the fo..")
        {
            PlayerPrefs.SetInt("BasementKey", 1);
        }

        if (lines.Substring(0, 5).ToLower() == "waaaa")
        {
            if (MrFaxen.GetComponent<SpriteRenderer>().sprite !=  MrFoxNameTag)
            {
                PlayerPrefs.SetInt("AppleAward", PlayerPrefs.GetInt("AppleAward") + 1);
                PauseMenu.appleAward = PlayerPrefs.GetInt("AppleAward");
            }

            MrFaxen.GetComponent<SpriteRenderer>().sprite = MrFoxNameTag;            
            sidequests.Fox(true);
        }

        if (lines.Substring(0, 5).ToLower() == "shchh")
        {
            sidequests.Milk(true);
            PlayerPrefs.SetInt("Cookie", 1);
        }

        if (lines.Substring(0, 7).ToLower() == "hey...." && sidequests.AngryBetaTesterDone == 1)
        {
            GameObject.Find("AngryHampus").GetComponent<TriggerDialogue>().Talk();

            //HildeZone.SetActive(false);
            PlayerPrefs.SetInt("HasJumpyBoots", 1);
        }
    }
}

