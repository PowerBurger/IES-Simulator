using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStuff : MonoBehaviour {

    //THIS SCRIPT WILL NOT WORK WITHOUT A RIGIDBODY AND A COLLIDER WITH ISTRIGGER!

    public string objectName = "";

	void Start ()
    {
        if (PlayerPrefs.GetInt(objectName) == 1)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "FistCol")
        {
            GameObject.Find("PickupSound").GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt(objectName, 1);
            Destroy(gameObject);
        }
    }
}
