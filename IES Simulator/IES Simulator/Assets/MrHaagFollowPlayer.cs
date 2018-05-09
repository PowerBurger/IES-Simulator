using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrHaagFollowPlayer : MonoBehaviour
{
    public int normalSpeed;
    private GameObject FPSController;
    public bool isMad;

    void Start()
    {
        FPSController = GameObject.Find("FPSController");
    }
    void Update()
    {
        //transform.LookAt(FPSController.transform);

            if (isMad)
            {
                //GÅ FKN FRAM
                transform.Translate(Vector3.back * normalSpeed * Time.deltaTime);
            } 
    }
}
