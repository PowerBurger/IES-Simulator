using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrFox : MonoBehaviour {

    public TextAsset MrFoxText;
    private TextBoxManager theTextBox;
    private Sidequests sidequests;
    public GameObject MrFoxCharacter;

	void Start ()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
        sidequests = FindObjectOfType<Sidequests>();
	}

	void Update ()
    {
		if(PlayerPrefs.GetInt("FoxDone") == 2)
        {
            MrFoxCharacter.SetActive(false);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ColDetector" && PlayerPrefs.GetInt("FoxMedallion") == 1 && sidequests.FoxDone == 1)
        {
            GameObject.Find("MrFoxQuestDone").GetComponent<TriggerDialogue>().Talk();
        }
    }
}
