using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private BossTriggered bossTriggered;

    public Transform target;
    public Transform staticTarget;
    public Transform myTransform;
    public int normalSpeed;
    public int superSpeed;

    public float timer1;
    public float timer2;
    public bool isMad;

    void Start()
    {
        bossTriggered = FindObjectOfType<BossTriggered>();
    }
    void Update ()
    {
        if (!isMad && bossTriggered.bossIsActive == true)
        {
            timer1 += Time.deltaTime;
        }
        else if(bossTriggered.bossIsActive == true)
        {
            timer2 += Time.deltaTime;
        }

        if(timer1 >= 10)
        {
            isMad = true;
            timer1 = 0;
        }

        if (timer2 >= 1)
        {
            isMad = false;
            timer2 = 0;
        }

        if (bossTriggered.bossIsActive == true)
        {
            if (!isMad)
            {
                transform.Translate(Vector3.back * normalSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.back * superSpeed * Time.deltaTime);
            }
        }
	}
}
