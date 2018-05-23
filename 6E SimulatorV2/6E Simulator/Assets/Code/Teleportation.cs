using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour {

    public GameObject player;
    public GameObject House;
    public GameObject MrHouse;
    public GameObject MrHouseNameTag;
    public Renderer portal;
    public Material []blue;

	void Start ()
    {
        portal = GetComponent<Renderer>();
        portal.enabled = true;

		if(PlayerPrefs.GetInt("HouseActivated") == 1)
        {
            House.SetActive(true);
            MrHouseNameTag.SetActive(true);
            MrHouse.GetComponent<SpriteRenderer>().enabled = true;
            MrHouse.GetComponent<Rigidbody>().useGravity = true;
        }

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
        if(other.gameObject.name == "ColDetector" && PlayerPrefs.GetInt("AppleAward") >= 3)
        {
            PlayerPrefs.SetInt("HouseActivated", 1);
            House.SetActive(true);
            MrHouseNameTag.SetActive(true);
            MrHouse.GetComponent<SpriteRenderer>().enabled = true;
            MrHouse.GetComponent<Rigidbody>().useGravity = true;
            player.transform.position = new Vector3(1229.1f, 91.8f, 8.1f);
        }
    }
}
