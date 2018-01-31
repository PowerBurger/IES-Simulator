using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveUp : MonoBehaviour {

    public bool hasClicked;
    public float MoveSpeed;
    public bool isDone;
    public Text txtRef;
    public Text txtRef2;
    public Text txtRef3;
    public static string myName;

    void Start ()
    {
		
	}
	

	void Update ()
    {
        if (Input.GetMouseButtonDown(0)) 
        {

            Application.LoadLevel("Schoolyard");

            /*if (isDone == false)
            {
                hasClicked = true;
                txtRef.text = "YOUR CHARACTER";
                txtRef2.text = "PICK";
                txtRef3.text = "";

            }
            */

           
                
        }

        if (Input.GetMouseButtonDown(0) && isDone == true)
        {          
            //Application.LoadLevel("Schoolyard");            
        }
            


        if (hasClicked)
        {
            transform.Translate(Vector3.up * Time.deltaTime * MoveSpeed);
        }

        if (transform.position.y > (Screen.height / 5))
        {

            isDone = true;
            hasClicked = false;

        }

       
	}
}
