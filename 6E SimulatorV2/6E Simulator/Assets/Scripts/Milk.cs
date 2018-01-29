using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

[RequireComponent(typeof(AudioSource))]
public class Milk : MonoBehaviour
{

    void Start()
    {
        if (PlayerPrefs.GetInt("Milk") == 1)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ColDetector")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            PlayerPrefs.SetInt("Milk", 1);
        }
    }
}
