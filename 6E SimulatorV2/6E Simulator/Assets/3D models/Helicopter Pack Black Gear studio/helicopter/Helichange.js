#pragma strict

var HelicopterPrefabs:GameObject[];
var CurrentHelicopter:int=0;
var HelicopterDefault:GameObject;
var gui:GUIStyle;
var hSliderValue : float = 1.5;
var Leftjoy:Joystick;
var Rightjoy:Joystick;

private var Currenthelip:Transform;


function Start () {

}

function Update () {
if(Input.GetKeyDown(KeyCode.C)){
Currenthelip=HelicopterDefault.transform;
Destroy(HelicopterDefault);
HelicopterDefault=Instantiate(HelicopterPrefabs[CurrentHelicopter],Currenthelip.position,Currenthelip.rotation);
++CurrentHelicopter;
if(CurrentHelicopter==HelicopterPrefabs.Length){
CurrentHelicopter=0;
}
}


}
function OnGUI(){

HelicopterDefault.GetComponent(helifin).forward_Rotor_Torque_Multiplier=hSliderValue;
HelicopterDefault.GetComponent(helifin).sideways_Rotor_Torque_Multiplier=hSliderValue;

hSliderValue = GUI.HorizontalSlider (Rect (Screen.height-25, 25, 100, 30), hSliderValue, 0.5, 3);
    GUI.Label(Rect(0,0,Screen.width,Screen.height),"\n\nUse slider to change torque multiplier",gui);
    #if !UNITY_ANDROID
    GUI.Label(Rect(0,0,Screen.width,Screen.height),"\n\n\nUse up to lift, down to decrease lift, \nw a s d keys or mouse to move\nright and left to rotate\nspace and rmb to fire\nc to change helicopter\nf to change camera",gui);
    #endif

}