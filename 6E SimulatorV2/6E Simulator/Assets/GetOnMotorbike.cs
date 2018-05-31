using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GetOnMotorbike : MonoBehaviour {

    bool isFollowingPlayer = false;
    public static bool isDriving = false;
    private GameObject thePlayer;

	// Use this for initialization
	void Start ()
    {
        thePlayer = GameObject.Find("FPSController");
	}
	
	// This is called 30 frames per second if u r a peasant.
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl) && isDriving)
        {
            GetOff();
            isFollowingPlayer = false;
        }

        if (isFollowingPlayer == true)
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
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_UseHeadBob = false;
        GameObject.Find("ctrl to jump off").GetComponent<Text>().enabled = true;
    }

    public void GetOff()
    {

        isDriving = false;
        isFollowingPlayer = false;

        //Move player a bit
        Vector3 playernewpos;
        playernewpos = GameObject.Find("FPSController").transform.position;
        playernewpos.x += 10f;
        GameObject.Find("FPSController").transform.position = playernewpos;

        thePlayer.transform.Find("Height").transform.position = new Vector3(thePlayer.transform.Find("Height").transform.position.x, thePlayer.transform.Find("Height").transform.position.y - 1.6f, thePlayer.transform.Find("Height").transform.position.z);
        

        
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_UseHeadBob = true;
        GameObject.Find("ctrl to jump off").GetComponent<Text>().enabled = false;

        isDriving = false;
        isFollowingPlayer = false;
    }
}
