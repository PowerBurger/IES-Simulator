using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentLaunch : MonoBehaviour
{


    void Start()
    {

    }


    void Update()
    {
        if(transform.position.x > 64.17f && transform.position.x < 71.4f && transform.position.z < -46.12f && transform.position.z > -53.88f && transform.position.y < 10.85f)
        {
            
            transform.position = new Vector3(22.3f, 353.1f, -170.5f);
        }
    }
}
   
