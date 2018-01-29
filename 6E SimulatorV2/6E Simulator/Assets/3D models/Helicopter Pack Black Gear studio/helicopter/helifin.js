
#pragma strict
var main_Rotor_GameObject : GameObject;
var tail_Rotor_GameObject : GameObject;
var max_Rotor_Force : float=22241.1081;
var max_Rotor_Velocity :float=7200;
var leftjoystick : Joystick;
var rightjoystick :Joystick;
var StablisingConstant : float=2f;
static var rotor_Velocity :float=0.0;
private var rotor_Rotation :float=0.0;
var max_tail_Rotor_Force : float=15000.0;
	public var mainrotor_axis : int=1;
	public var tailrotor_axis : int=1;
var max_Tail_Rotor_Velocity :float=2200.0;
private var tail_rotor_Velocity :float=0.0;
private var tail_rotor_Rotation :float=0.0;
var forward_Rotor_Torque_Multiplier:float=1.5;
var sideways_Rotor_Torque_Multiplier :float=2;
static var main_Rotor_Active: boolean =true;
var Hover_Const:float=2f;
static var tail_Rotor_Active: boolean=true;
var RotorSpeedIncreaseConstant:float=2;
var RestoringTorqueMultiplier:float=1;
var Wind : GameObject;
var dust:GameObject;
var leave:GameObject;
private var healthy:helispark;
var maxHeight:float;
var gui:GUIStyle;
var labelPosition : Rect;
var layer:LayerMask=0;
private var timer:float=0f;
private var cannotRestore:boolean=false;
var altitude:float;
var refr : GameObject;



function Awake () {
healthy=gameObject.GetComponent(helispark);
}

function FixedUpdate() {//Main physics forces section
if(healthy.state==true){
}
var torqueValue:Vector3;
var controlTorque :Vector3 ;
var value1:float;
var value2:float;
if(Input.GetAxis("Vertical")!=0){
value1=Input.GetAxis("Vertical");
}else{
value1=Input.GetAxis("Mouse Y");
}
if(Input.GetAxis("Horizontal2")!=0){
value2=Input.GetAxis("Horizontal2");
}else {
value2=-Input.GetAxis("Mouse X");
}

controlTorque=Vector3( -value1* forward_Rotor_Torque_Multiplier,1,-value2*sideways_Rotor_Torque_Multiplier);



#if UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_BLACKBERRY || UNITY_TIZEN
controlTorque  = Vector3( leftjoystick.position.y* forward_Rotor_Torque_Multiplier,1.0,rightjoystick.position.x*sideways_Rotor_Torque_Multiplier);
#endif
if (main_Rotor_Active==true){
torqueValue+=(controlTorque*max_Rotor_Force*rotor_Velocity);
if (altitude<maxHeight){
GetComponent.<Rigidbody>().AddRelativeForce(Vector3.up*max_Rotor_Force*rotor_Velocity);
}
}
if(GetComponent.<Rigidbody>().velocity.y<0&&rotor_Velocity<0.3){
GetComponent.<Rigidbody>().AddForce(Vector3.down*30000);
}
if(Vector3.Angle(Vector3.up,transform.up)<80){
transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.Euler(0,transform.rotation.eulerAngles.y,360),Time.deltaTime*rotor_Velocity*StablisingConstant);
}


if(tail_Rotor_Active==true){
torqueValue-=(Vector3.up*max_tail_Rotor_Force*tail_rotor_Velocity);
}
//Fix v4.0 Helicopter not restoring z position when bent forward
if(Input.GetAxis("Vertical")!=0){
if(Input.GetAxis("Horizontal2")==0){
if(transform.localRotation.eulerAngles.z>5&&transform.localRotation.eulerAngles.z<80){
GetComponent.<Rigidbody>().AddRelativeTorque(0,0,-rotor_Velocity*1000*transform.localRotation.eulerAngles.z*RestoringTorqueMultiplier);
}
if(transform.localRotation.eulerAngles.z>190&&transform.localRotation.eulerAngles.z<355){
GetComponent.<Rigidbody>().AddRelativeTorque(0,0,rotor_Velocity*1000*(360-transform.localRotation.eulerAngles.z)*RestoringTorqueMultiplier);
}
}
}

GetComponent.<Rigidbody>().AddRelativeTorque(torqueValue);
}

function Start () {

}

function dead(){

Destroy(Wind);
Destroy(GetComponent(helifin));
}

function Update () {

if(healthy.state==true){
dead();
}
if(main_Rotor_Active==true){
switch(mainrotor_axis)
		{
			case 1:
				main_Rotor_GameObject.transform.Rotate(rotor_Velocity*40,0,0);
				break;
			case 2:
				main_Rotor_GameObject.transform.Rotate(0,rotor_Velocity*40,0);
				break;
			case 3:
				main_Rotor_GameObject.transform.Rotate(0,0,rotor_Velocity*40);
				break;	
				
		}

}
if(tail_Rotor_Active==true) {
#if UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_BLACKBERRY || UNITY_TIZEN
if(leftjoystick.position.x>0){
switch(tailrotor_axis)
		{
			case 1:
				tail_Rotor_GameObject.transform.Rotate(tail_rotor_Velocity*20,0,0);
				break;
			case 2:
			tail_Rotor_GameObject.transform.Rotate(0,tail_rotor_Velocity*20,0);
				break;
			case 3:
				tail_Rotor_GameObject.transform.Rotate(0,0,tail_rotor_Velocity*20);
				break;	
				
		}

}
#endif
if(Input.GetAxis("Horizontal")==1){
switch(tailrotor_axis)
		{
			case 1:
				tail_Rotor_GameObject.transform.Rotate(tail_rotor_Velocity*20,0,0);
				break;
			case 2:
			tail_Rotor_GameObject.transform.Rotate(0,tail_rotor_Velocity*20,0);
				break;
			case 3:
				tail_Rotor_GameObject.transform.Rotate(0,0,tail_rotor_Velocity*20);
				break;	
				
		}

}else {
switch(tailrotor_axis)
		{
			case 1:
				tail_Rotor_GameObject.transform.Rotate(tail_rotor_Velocity*20,0,0);
				break;
			case 2:
			tail_Rotor_GameObject.transform.Rotate(0,tail_rotor_Velocity*20,0);
				break;
			case 3:
				tail_Rotor_GameObject.transform.Rotate(0,0,tail_rotor_Velocity*20);
				break;	
				
		}
}
}
rotor_Rotation+=max_Rotor_Velocity*rotor_Velocity*Time.deltaTime;
tail_rotor_Rotation+=max_Tail_Rotor_Velocity*rotor_Velocity*Time.deltaTime;
var hover_Rotor_Velocity=(GetComponent.<Rigidbody>().mass*Mathf.Abs(Physics.gravity.y)/max_Rotor_Force);
var hover_Tail_Rotor_Velocity=(max_Rotor_Force*rotor_Velocity)/max_tail_Rotor_Force;
if(Input.GetAxis("Vertical2")!=0.0) {
rotor_Velocity+=Input.GetAxis("Vertical2")*RotorSpeedIncreaseConstant*0.001;
}else{
rotor_Velocity=Mathf.Lerp(rotor_Velocity,hover_Rotor_Velocity,Time.deltaTime*Time.deltaTime*5*Hover_Const);
}
#if UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_BLACKBERRY || UNITY_TIZEN
if(rightjoystick.position.y!=0.0) {
rotor_Velocity+=rightjoystick.position.y*RotorSpeedIncreaseConstant*0.001;
}else{
rotor_Velocity=Mathf.Lerp(rotor_Velocity,hover_Rotor_Velocity,Time.deltaTime*Time.deltaTime*);
}
#endif
if(Input.GetAxis("Horizontal")!=0){
tail_rotor_Velocity=hover_Tail_Rotor_Velocity-Input.GetAxis("Horizontal");
}else{
tail_rotor_Velocity=hover_Tail_Rotor_Velocity-Input.GetAxis("Mouse X");
}
#if UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_BLACKBERRY || UNITY_TIZEN
tail_rotor_Velocity=hover_Tail_Rotor_Velocity-leftjoystick.position.x;
#endif
if(rotor_Velocity>1.0){
rotor_Velocity=1.0;
}else if (rotor_Velocity<0.0){
rotor_Velocity=0.0;
}
GetComponent.<AudioSource>().pitch=rotor_Velocity;
var groundHit:RaycastHit;
Physics.Raycast(refr.transform.position,-Vector3.up,groundHit,10000,layer);
altitude=groundHit.distance;

extrafx();
}

function extrafx() {
if(rotor_Velocity>0.4){
Wind.SetActive(true);

}else {
Wind.SetActive (false);
}


if(healthy.state==false&&altitude<15){
dust.GetComponent.<ParticleEmitter>().emit=true;
dust.GetComponent.<ParticleEmitter>().minEnergy=2.2;
dust.GetComponent.<ParticleEmitter>().maxEnergy=(rotor_Velocity/1)*6;
leave.GetComponent.<ParticleEmitter>().emit=true;
leave.GetComponent.<ParticleEmitter>().minEnergy=2.2;
leave.GetComponent.<ParticleEmitter>().maxEnergy=(rotor_Velocity/1)*6;
}else {
dust.GetComponent.<ParticleEmitter>().emit=false;
leave.GetComponent.<ParticleEmitter>().emit=false;
}
}

function OnGUI(){


GUI.Label(labelPosition,"\nVel up - "+GetComponent.<Rigidbody>().velocity.y+"m/s",gui);

}