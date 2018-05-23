using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRight : MonoBehaviour
{
    public float speed;
    private Text area;
    void Start ()
    {
		
	}
	
	
	void Update ()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
	}



    public void changeText(string theArea)
    {
        area = GetComponent<Text>();
        area.text = theArea;
        transform.position = new Vector3(-836.8f, 28f, 0f);
    }
}

