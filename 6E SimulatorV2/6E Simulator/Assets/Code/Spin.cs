using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public int rotSpeed;
    
	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Rotate(Vector3.back * Time.deltaTime * rotSpeed);
    }
}
