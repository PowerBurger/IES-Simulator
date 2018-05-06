using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivateTextAtLine : MonoBehaviour
{

    public TextAsset theText;
    public TextAsset AngryBuster;
    public TextAsset Intro;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;
    public Sidequests sidequests;

    public bool destroyWhenActivated;
    public bool requireButtonPress;
    private bool waitForPress;

    public GameObject talk;
    public GameObject click;

    public string Person;
    





    void Start ()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
        sidequests = FindObjectOfType<Sidequests>();
    }
	
	
	void Update ()
    {		
        if(waitForPress && Input.GetMouseButtonDown(0) && TextBoxManager.isActive == false)
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();


            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
  
        if(talk.activeSelf && Input.GetMouseButtonDown(1) && sidequests.ACounterStrikeDone == 1 && gameObject.name == "PunchZone")
        {
            /*theTextBox.ReloadScript(AngryBuster);
            theTextBox.currentLine = 1;
            theTextBox.endAtLine = 7;
            theTextBox.EnableTextBox();
            */
        }

    }



    void OnTriggerEnter(Collider other)
    {

      

        if (other.name == "ColDetector")
        {
            if (requireButtonPress == true)
            {
                talk.SetActive(true);
                click.SetActive(true);
                theTextBox.shouldShowTalk = true;
                waitForPress = true;
                return;
            }
            else
            {
                theTextBox.shouldShowTalk = false;
            }

            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.shouldShowTalk = false;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();
            

            if(destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }                  
    }

    void OnTriggerExit(Collider other)
    {
     

        if(other.name == "ColDetector" && requireButtonPress == true)
        {            
            waitForPress = false;
            talk.SetActive(false);
            click.SetActive(false);
        }

     
    }

    

  
}
