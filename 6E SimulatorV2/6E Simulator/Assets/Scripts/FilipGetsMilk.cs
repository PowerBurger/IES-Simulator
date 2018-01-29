using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilipGetsMilk : MonoBehaviour
{

    public TextAsset FilipGetsMilkText;
    private TextBoxManager theTextBox;
    private Sidequests sidequests;
    public GameObject FilipCharacter;

    void Start()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
        sidequests = FindObjectOfType<Sidequests>();
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("MilkDone") == 2)
        {
            FilipCharacter.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ColDetector" && PlayerPrefs.GetInt("Milk") == 1 && sidequests.MilkDone == 1)
        {
            theTextBox.ReloadScript(FilipGetsMilkText);
            theTextBox.currentLine = 1;
            theTextBox.endAtLine = 6;
            theTextBox.EnableTextBox();
        }
    }
}
