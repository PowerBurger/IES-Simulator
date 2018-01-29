using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{

    public static bool studentLaunch;
    public static bool schoolyard;
    public static bool F;
    public static bool D;
    public static bool C;
    public static bool E;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!studentLaunch)
        {
            if (transform.position.z > -57.44f && transform.position.z < -54.88f)// Test z position
            {
                if (transform.position.x > -50.8f && transform.position.x < -40.71)//Test x
                {
                    if (transform.position.y > -2.54f && transform.position.y < 11.7f) // test y
                    {
                        MoveRight instanceOfMoveRight = GameObject.Find("Location").GetComponent<MoveRight>();
                        instanceOfMoveRight.changeText("Student Launch");
                        studentLaunch = true;
                    }
                }
            }
        }

        if (!F)
        {
            if (transform.position.z > -57.44f && transform.position.z < -54.88f)// Test z position
            {
                if (transform.position.x > -50.8f && transform.position.x < -40.71)//Test x
                {
                    if (transform.position.y > 13.8f && transform.position.y < 23.4f) // test y
                    {
                        MoveRight instanceOfMoveRight = GameObject.Find("Location").GetComponent<MoveRight>();
                        instanceOfMoveRight.changeText("F CORRIDOR");                        
                        F = true;
                    }
                }
            }
        }

        if (!D)
        {
            if (transform.position.z > -57.44f && transform.position.z < -54.88f)// Test z position
            {
                if (transform.position.x > -50.8f && transform.position.x < -40.71f)//Test x
                {
                    if (transform.position.y > 23.4f && transform.position.y < 33.81f) // test y
                    {
                        MoveRight instanceOfMoveRight = GameObject.Find("Location").GetComponent<MoveRight>();
                        instanceOfMoveRight.changeText("D CORRIDOR");
                        D = true;
                    }
                }
            }
        }

        if (!F)
        {
            if (transform.position.z > -57.24f && transform.position.z < -55.49f)// Test z position
            {
                if (transform.position.x > 117.62f && transform.position.x < 127.9f)//Test x
                {
                    if (transform.position.y > 13.75f && transform.position.y < 19.14f) // test y
                    {
                        MoveRight instanceOfMoveRight = GameObject.Find("Location").GetComponent<MoveRight>();
                        instanceOfMoveRight.changeText("F CORRIDOR");
                        F = true;
                    }
                }
            }
        }

        if (!D)
        {
            if (transform.position.z > -57.24f && transform.position.z < -55.49f)// Test z position
            {
                if (transform.position.x > 117.62f && transform.position.x < 127.9f)//Test x
                {
                    if (transform.position.y > 25.24f && transform.position.y < 30.56f) // test y
                    {
                        MoveRight instanceOfMoveRight = GameObject.Find("Location").GetComponent<MoveRight>();
                        instanceOfMoveRight.changeText("D CORRIDOR");
                        D = true;
                    }
                }
            }
        }

        if (!E)
        {
            if (transform.position.z > -209.24f && transform.position.z < -207.247f)// Test z position
            {
                if (transform.position.x > 116.94f && transform.position.x < 128.08f)//Test x
                {
                    if (transform.position.y > 13.69f && transform.position.y < 20.64f) // test y
                    {
                        MoveRight instanceOfMoveRight = GameObject.Find("Location").GetComponent<MoveRight>();
                        instanceOfMoveRight.changeText("E CORRIDOR");
                        E = true;
                    }
                }
            }
        }

        if (!C)
        {
            if (transform.position.z > -209.24f && transform.position.z < -207.247f)// Test z position
            {
                if (transform.position.x > 116.94f && transform.position.x < 128.08f)//Test x
                {
                    if (transform.position.y > 25.305f && transform.position.y < 31.73f) // test y
                    {
                        MoveRight instanceOfMoveRight = GameObject.Find("Location").GetComponent<MoveRight>();
                        instanceOfMoveRight.changeText("C CORRIDOR");
                        C = true;
                    }
                }
            }
        }

        if (!E)
        {
            if (transform.position.z > -99.37f && transform.position.z < -97.07f)// Test z position
            {
                if (transform.position.x > 116.94f && transform.position.x < 128.08f)//Test x
                {
                    if (transform.position.y > 13.69f && transform.position.y < 20.64f) // test y
                    {
                        MoveRight instanceOfMoveRight = GameObject.Find("Location").GetComponent<MoveRight>();
                        instanceOfMoveRight.changeText("E CORRIDOR");
                        E = true;
                    }
                }           
            }
        }

        if (!C)
        {
            if (transform.position.z > -99.37f && transform.position.z < -97.07f)// Test z position
            {
                if (transform.position.x > 116.94f && transform.position.x < 128.08f)//Test x
                {
                    if (transform.position.y > 25.305f && transform.position.y < 31.73f) // test y
                    {
                        MoveRight instanceOfMoveRight = GameObject.Find("Location").GetComponent<MoveRight>();
                        instanceOfMoveRight.changeText("C CORRIDOR");
                        C = true;
                    }
                }
            }
        }
    }

    public void Schoolyard()
    {
        if (!schoolyard)
        {
            MoveRight instanceOfMoveRight = GameObject.Find("Location").GetComponent<MoveRight>();
            instanceOfMoveRight.changeText("Schoolyard");
            schoolyard = true;
        }
    }
}

