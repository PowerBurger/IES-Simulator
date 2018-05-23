using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Detension : MonoBehaviour {

    public float TimeLeft;
    private string TimeLeftString;
    private Text Min;
    public float DetensionTextTimer = 2;
    public GameObject background;
    public GameObject detensionText;
    public GameObject textBackground;

	void Start ()
    {
        Min = GetComponent<Text>();

        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

	void Update ()
    {
        TimeLeft -= 1 * Time.deltaTime;
        TimeLeftString = TimeLeft.ToString();

        if(TimeLeft > 10)
        {
            Min.text = TimeLeftString.Substring(0, 2) + "M";
        }

        if (TimeLeft < 10)
        {
            Min.text = TimeLeftString.Substring(0, 1) + "M";
        }

        if(TimeLeft <= 1)
        {
            Application.LoadLevel("Schoolyard");
        }

        if(DetensionTextTimer > 0)
        {
            DetensionTextTimer -= Time.deltaTime;
        }

        if(DetensionTextTimer <= 0)
        {
            background.SetActive(false);
            detensionText.SetActive(false);
            textBackground.SetActive(false);
            gameObject.GetComponent<AudioSource>().enabled = false;
        }
    }
}
