#pragma strict
public var rocketPrefab : Rigidbody;
public var positionr: Transform;
var launchsound:AudioClip;
private var timer:float=0;
private var Helispark:helispark;
var gunparticle:GameObject;
var gunsound:AudioClip;
var muzzle:GameObject;
var gunhit:GameObject;
function Awake () {
Helispark=gameObject.GetComponent(helispark);
}
function Update ()
{
timer+=Time.deltaTime;

    if(Input.GetButtonDown("Fire1")&&timer>2&&Helispark.state==false)
    {
        timer=0;
        var rocketInstance : Rigidbody;
        rocketInstance = Instantiate(rocketPrefab, positionr.position, positionr.rotation);
        rocketInstance.AddForce(positionr.forward * 5000);
        GetComponent.<AudioSource>().PlayOneShot(launchsound);
    }
    #if !UNITY_ANDROID 
    if(Input.GetKey(KeyCode.Mouse0)&&Helispark.state==false){
    Fire();
    }
    
    else {
    muzzle.SetActive(false);
    } 
    #endif
}

function OnGUI() {
#if UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_BLACKBERRY || UNITY_TIZEN
if( GUI.Button(Rect(Screen.width-(Screen.width/6),Screen.height/2,60,30),"Fire")){
timer=0;
        var rocketInstance : Rigidbody;
        rocketInstance = Instantiate(rocketPrefab, positionr.position, positionr.rotation);
        rocketInstance.AddForce(positionr.forward * 2500);
        audio.PlayOneShot(launchsound);
}
if( GUI.Button(Rect(Screen.width-(Screen.width/6),Screen.height/2-40,60,30),"Gun")){
Fire();
}else {
    muzzle.SetActive(false);
    } 

#endif
}
function Fire() {
Instantiate(gunparticle,positionr.position,positionr.rotation);
    muzzle.SetActive(true);
    GetComponent.<AudioSource>().PlayOneShot(gunsound);
    var hit:RaycastHit;
    if(Physics.Raycast(positionr.position, positionr.forward, hit, 50))
{
if(hit.collider.GetComponent.<Rigidbody>())
{
var vnorm = Quaternion(hit.normal.z, hit.normal.y, -hit.normal.x, 1); //this is for creating a Quaternion variable that contains the rotation of the surface i hit to put in the instantiate.


var instant:GameObject=Instantiate(gunhit, hit.point, vnorm); 


hit.collider.GetComponent.<Rigidbody>().AddForceAtPosition(transform.forward * 100, hit.point);
}
else
{
var vnorme = Quaternion(hit.normal.z, hit.normal.y, -hit.normal.x, 1);

var instant2:GameObject=Instantiate(gunhit, hit.point, vnorme);	

}
    }
}