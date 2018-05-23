using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchCol : MonoBehaviour {

    private Sidequests sidequests;

	void Start ()
    {
        sidequests = FindObjectOfType<Sidequests>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision collision)
    {
        print(gameObject.name);
        if(collision.gameObject.name == "ColDetector")
        {
            print("it workz");
            sidequests.AddBN(1);
        }
    }
}
