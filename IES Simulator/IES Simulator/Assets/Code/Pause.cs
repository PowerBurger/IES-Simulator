using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isActive;

	// Use this for initialization
	void Start ()
    {
        isActive = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
		//if(Input.GetKeyDown(KeyCode.Escape))
        /*{
            isActive = !isActive;
            gameObject.SetActive(true);

        }
        */

        if(isActive)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }


	}
}
