using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOnMotorbike : MonoBehaviour {

    bool isFollowingPlayer = false;
    public static bool isDriving = false;
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
            Vector3 temprot = transform.eulerAngles;
            temprot.y = thePlayer.transform.eulerAngles.y;
            transform.eulerAngles = temprot;

        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FistCol")
        {
            if (!isFollowingPlayer && !isDriving)
            {
                GetOn();
            }
        }
    }

    public void GetOn()
    {
        isDriving = true;
        isFollowingPlayer = true;
        thePlayer.transform.Find("Height").transform.position = new Vector3(thePlayer.transform.Find("Height").transform.position.x, thePlayer.transform.Find("Height").transform.position.y + 1.6f, thePlayer.transform.Find("Height").transform.position.z);
    }
}
