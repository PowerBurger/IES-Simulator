#pragma strict
var detonator:GameObject;
var scorchMark:GameObject;

function Start () {

}

function Update () {

}
function FixedUpdate() {


}
function OnCollisionEnter(other : Collision) {
       var contact = other.contacts[0];
       var rot = Quaternion.FromToRotation(Vector3.up,contact.normal);
		
		
		var pos = contact.point;
		Instantiate(detonator,pos,rot);
		scorchMark=Instantiate(scorchMark,Vector3.zero,Quaternion.identity);
		
		
		scorchMark.transform.position = pos;
		scorchMark.transform.Translate(Vector3.up);
		scorchMark.transform.rotation=rot;
		scorchMark.transform.up=contact.normal ;
		
		scorchMark.transform.eulerAngles.y = Random.Range (0.0, 90.0);
		scorchMark.transform.parent=other.transform;
		Destroy(gameObject);
}