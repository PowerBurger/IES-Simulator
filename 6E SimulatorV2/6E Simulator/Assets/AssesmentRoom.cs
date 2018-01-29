using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssesmentRoom : MonoBehaviour {

    public static float timer = 3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timer >= 0 && Application.loadedLevelName == "Assesment")
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            Application.LoadLevel("Assesment2");
        }
    }
}
