using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Eat : MonoBehaviour {

    public GameObject f1;
    public GameObject f2;
    public GameObject f3;
    public GameObject f4;
    public GameObject f5;
    public GameObject f6;
    public GameObject f7;

    public int Eaten;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            Eaten -= 1;
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }

        if(Eaten == 6)
        {
            f7.SetActive(false);
        }

        if (Eaten == 5)
        {
            f6.SetActive(false);
        }

        if (Eaten == 4)
        {
            f5.SetActive(false);
        }

        if (Eaten == 3)
        {
            f4.SetActive(false);
        }

        if (Eaten == 2)
        {
            f3.SetActive(false);
        }

        if (Eaten == 1)
        {
            f2.SetActive(false);
        }

        if (Eaten == 0)
        {
            f1.SetActive(false);
        }

        if (Eaten == 0)
        {
            Application.LoadLevel("Schoolyard");
        }
    }
}
