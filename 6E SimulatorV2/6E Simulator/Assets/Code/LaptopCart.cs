using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopCart : MonoBehaviour {

    private Sidequests sidequests;
    public GameObject MrBassonZone;
    private TextBoxManager theTextBox;
    public TextAsset MrBassonGetsLaptops;

	void Start ()
    {
        sidequests = FindObjectOfType<Sidequests>();
        theTextBox = FindObjectOfType<TextBoxManager>();

        if(PlayerPrefs.GetInt("LaptopsDone") == 2)
        {
            MrBassonZone.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "MrBassonZone" && PlayerPrefs.GetInt("LaptopsDone") == 1)
        {
            if(MrBassonZone.activeSelf == true)
            {
                PauseMenu.appleAward += 1;
            }
            GameObject.Find("MrBassonQuestDone").GetComponent<TriggerDialogue>().Talk();
            MrBassonZone.SetActive(false);
        }
    }
}
