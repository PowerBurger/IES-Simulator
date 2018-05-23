using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealPants : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(PlayerPrefs.GetString("Pants") == "JumpyPants")
        {
            gameObject.SetActive(true);
        }
	}
}
