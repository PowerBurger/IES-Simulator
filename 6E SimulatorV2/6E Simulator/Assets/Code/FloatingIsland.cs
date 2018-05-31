using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingIsland : MonoBehaviour {

    public Animator island;
    public float timer;
    private bool timerStarted;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(timerStarted && timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0 && timerStarted)
        {
            island.enabled = false;
            GameObject.Find("FortiBot").GetComponent<MrHaagFollowPlayer>().isMad = true;
        }
        
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "FistCol" && PlayerPrefs.GetInt("OrbOfUnblocking") == 1 && timerStarted == false)
        {
            island.Play("floatingIslandRise"); 
            timer = 20;
            timerStarted = true;
            //GetComponent<SphereCollider>().enabled = false;
        }
    }
}
   