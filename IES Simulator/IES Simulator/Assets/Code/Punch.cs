using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Punch : MonoBehaviour
{
    public AudioClip clip;
    public float Volume;
    public float TimeLeft;
    public GameObject fist;
    public GameObject fistCollider;
    public GameObject RasmusZone;
    public GameObject HildeZone;
    public GameObject open;
    public TextBoxManager theTextBox;
    public Sidequests sidequests;
    public PauseMenu pauseMenu;
    public TextAsset AngryBuster;
    public TextAsset AngryHampus;
    public GameObject Cam;

    //Inventory
    public GameObject Panel;
    public GameObject Player;
    public GameObject Box1;
    public GameObject Box2;
    public GameObject Box3;
    public GameObject Pants;
    public GameObject FoxMedallion;
    public GameObject Milk;
    public GameObject BasementKey;
    public Text BNText2;
    public Text respectText2;
    public GameObject Cookie;

    void Start ()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
        sidequests = FindObjectOfType<Sidequests>();
        pauseMenu =  FindObjectOfType<PauseMenu>();
    }
		
	void Update ()
    {
		if(Input.GetMouseButtonDown(1) && Application.platform != RuntimePlatform.Android)
        {           
            //AudioSource audio = GetComponent<AudioSource>();
            //audio.Play();
            TimeLeft = 1.5f;
        }
        if (TimeLeft > 0)
        {
            TimeLeft = TimeLeft - 1 * Time.deltaTime;
            fist.SetActive(true);
        }

        if(TimeLeft <= 0)
        {
            fist.SetActive(false);
        }

        BNText2.text = "BEHAVIOUR NOTICE    " + sidequests.BN.ToString();
        respectText2.text = "Apple award       " + PauseMenu.appleAward.ToString();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.name == "PunchZone" && Input.GetMouseButtonDown(1) && sidequests.ACounterStrikeDone == 1)
        {
            theTextBox.ReloadScript(AngryBuster);
            theTextBox.currentLine = 1;
            theTextBox.endAtLine = 7;
            theTextBox.EnableTextBox();
            RasmusZone.SetActive(false);
        }

        if (col.name == "PhoneZone" && Input.GetMouseButtonDown(1))
        {
            sidequests.AddBN(1);
        }

        if (col.name == "HampusZone" && Input.GetMouseButtonDown(1) && sidequests.AngryBetaTesterDone == 1)
        {           
            /*
            theTextBox.ReloadScript(AngryHampus);
            theTextBox.currentLine = 1;
            theTextBox.endAtLine = 9;
            theTextBox.EnableTextBox();
            HildeZone.SetActive(false);    
            */    
        }

        if (col.name == "DittSkåp" && Input.GetMouseButtonDown(0))
        {
            open.SetActive(false);
            pauseMenu.click.SetActive(false);
            Screen.lockCursor = false;
            FirstPersonController.canMove = false;
            Panel.SetActive(true);
            Cam.GetComponent<FirstPersonController>().enabled = false;

            if(PlayerPrefs.GetInt("HasJumpyBoots") == 1)
            {
                Pants.SetActive(true);
            }

            if(PlayerPrefs.GetInt("FoxMedallion") == 1)
            {
                FoxMedallion.SetActive(true);
            }

            if (PlayerPrefs.GetInt("Milk") == 1)
            {
                Milk.SetActive(true);
            }

            if (PlayerPrefs.GetInt("BasementKey") == 1)
            {
                BasementKey.SetActive(true);
            }

            if (PlayerPrefs.GetInt("Cookie") == 1)
            {
                Cookie.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "DittSkåp")
        {
            open.SetActive(true);
            pauseMenu.click.SetActive(true);
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "DittSkåp")
        {
            open.SetActive(false);
            pauseMenu.click.SetActive(false);            
        }
    }

    public void SkåpExit()
    {
        Cam.GetComponent<FirstPersonController>().enabled = true;
        Panel.SetActive(false);
        FirstPersonController.canMove = true;
        Screen.lockCursor = true;
        pauseMenu.click.SetActive(true);
        open.SetActive(true);
    }

    public void Exit()
    {
        Application.LoadLevel("TitleScreen");
    }
}
