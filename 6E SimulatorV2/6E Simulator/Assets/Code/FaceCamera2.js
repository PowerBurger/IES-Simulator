#pragma strict

function Start () {
	
}

function Update () 
{
    var v = transform.position - Camera.main.transform.position;
    v.y = 0.0;
    transform.rotation = Quaternion.LookRotation(v);
}
