using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{

    public GameObject pCam;
    public GameObject hCam;
    public bool isHel;
    private bool isDone;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if(isHel)
            {
                pCam.transform.position = hCam.transform.position;
            }
            isHel = !isHel;
            hCam.transform.position = pCam.transform.position;
            hCam.transform.rotation = pCam.transform.rotation;
            hCam.transform.Rotate(0, 180, 0);

            if (isHel)
            {
                pCam.SetActive(false);
                hCam.SetActive(true);
                Screen.lockCursor = true;
            }

            if (!isHel)
            {
                pCam.SetActive(true);
                hCam.SetActive(false);

            }
        }
    }
}
