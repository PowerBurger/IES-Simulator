using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class TextBoxManager : MonoBehaviour
{

    public GameObject textBox;
    public GameObject talk;
    public GameObject click;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public static bool isActive;
    public bool bShowSQ = false;






    void Start()
    {

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
        

        if(isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }

        DisableTextBox();
    }

    void Update()
    {

        if(!isActive)
        {
            return;
        }

        theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) )
        {
            currentLine += 1;
            talk.SetActive(false);
            click.SetActive(false);
        }

        // when talk done,allow sidequest
        if(currentLine > endAtLine)
        {
            DisableTextBox();
            talk.SetActive(true);
            click.SetActive(true);
            bShowSQ = true;

        }

    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
        FirstPersonController.canMove = false;
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
        FirstPersonController.canMove = true;
        
    }

    public void ReloadScript(TextAsset theText)
    {
        if(theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }


    }
}
