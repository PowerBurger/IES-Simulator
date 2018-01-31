using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

[RequireComponent(typeof(AudioSource))]
public class Fox : MonoBehaviour {

	void Start ()
    {
		if(PlayerPrefs.GetInt("FoxMedallion") == 1)
        {
            Destroy(gameObject);
        }
	}
	
	void Update ()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "ColDetector")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            PlayerPrefs.SetInt("FoxMedallion" , 1);    
        }
    }
}
