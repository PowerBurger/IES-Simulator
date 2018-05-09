using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingIsland : MonoBehaviour {

    public Animator island;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "FistCol" && PlayerPrefs.GetInt("OrbOfUnblocking") == 1)
        {
            island.Play("floatingIslandRise");
            //GetComponent<SphereCollider>().enabled = false;
        }
    }
}
   