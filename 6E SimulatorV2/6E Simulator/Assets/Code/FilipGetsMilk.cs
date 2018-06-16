using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilipGetsMilk : MonoBehaviour
{

    public TextAsset FilipGetsMilkText;
    private Sidequests sidequests;
    public GameObject FilipCharacter;

    void Start()
    {
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
            GameObject.Find("FilipCookieQuestDone").GetComponent<TriggerDialogue>().Talk();
        }
    }
}
