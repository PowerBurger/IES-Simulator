using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeOpen : MonoBehaviour
{

    private bool isColiding;

    public GameObject open;
    public GameObject clickIcon;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (open.activeSelf == true && Input.GetMouseButtonDown(0) && isColiding)
        {
            Application.LoadLevel("FirstBossFight");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ColDetector")
        {
            isColiding = true;
            open.SetActive(true);
            clickIcon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "ColDetector")
        {
            isColiding = false;
            open.SetActive(false);
            clickIcon.SetActive(false);
        }
    }
}
