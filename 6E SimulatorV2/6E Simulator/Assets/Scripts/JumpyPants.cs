using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class JumpyPants : MonoBehaviour {

    private FirstPersonController fps;
    public GameObject RealPants;

	// Use this for initialization
	void Start ()
    {
        fps = FindObjectOfType<FirstPersonController>();

        if (PlayerPrefs.GetString("Pants") == "JumpyPants")
        {
            fps.m_GravityMultiplier = 0.2f;
            RealPants.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void JumpyPantsOn()
    {
        PlayerPrefs.SetString("Pants", "JumpyPants");
        fps.m_GravityMultiplier = 0.2f;
        RealPants.SetActive(true);
    }
}
