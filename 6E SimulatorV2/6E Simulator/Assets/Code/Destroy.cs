using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		if(PlayerPrefs.GetInt("MrMatherDone") == 1)
        {
            GetComponent<BoxCollider>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
