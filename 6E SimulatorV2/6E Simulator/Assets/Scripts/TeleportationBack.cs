using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationBack : MonoBehaviour {

    public GameObject player;
    public Renderer portal;
    public Material []blue;

	void Start ()
    {
        portal = GetComponent<Renderer>();
        portal.enabled = true;

	}
	
	void Update ()
    {
		if(PlayerPrefs.GetInt("AppleAward") >= 3)
        {
            portal.sharedMaterial = blue[0];
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ColDetector")
        {
            Application.LoadLevel("Schoolyard");
        }
    }
}
