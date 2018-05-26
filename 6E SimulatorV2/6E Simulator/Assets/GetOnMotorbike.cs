using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOnMotorbike : MonoBehaviour {

    bool isFollowingPlayer = false;
    private GameObject thePlayer;

	// Use this for initialization
	void Start ()
    {
        thePlayer = GameObject.Find("FPSController");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(isFollowingPlayer == true)
        {
            transform.position = new Vector3(thePlayer.transform.position.x, thePlayer.transform.position.y - 1.5f, thePlayer.transform.position.z);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FistCol")
        {
            isFollowingPlayer = true;
        }
    }
}
