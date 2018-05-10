using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrHaagFollowPlayer : MonoBehaviour
{
    //THIS SCRIPT REQUIRES A FACE CAMERA SCRIPT!!!! DONT FORGET M8!!!
    public int normalSpeed;
    private GameObject FPSController;
    public bool isMad;

    void Start()
    {
        FPSController = GameObject.Find("FPSController");
    }
    void Update()
    {

            if (isMad)
            {
                //GÅ FKN FRAM
                transform.Translate(Vector3.back * normalSpeed * Time.deltaTime);
            } 
    }
}
