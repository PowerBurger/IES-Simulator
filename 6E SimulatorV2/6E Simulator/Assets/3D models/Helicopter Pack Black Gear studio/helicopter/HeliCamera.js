#pragma strict
var left:Transform;
var back:Transform;
var right:Transform;
var seat:Transform;


private var i :int=0;

function Start () {

}

function Update () {
if (i==0){
gameObject.GetComponent(SmoothFollow).enabled=true;
gameObject.GetComponent(SmoothFollow).target=back;
} else if(i==1){
gameObject.GetComponent(SmoothFollow).enabled=false;
transform.position=seat.position;
transform.rotation=seat.rotation;

}else if ( i==2){
gameObject.GetComponent(SmoothFollow).enabled=true;
gameObject.GetComponent(SmoothFollow).target=left;
}else if(i==3){
gameObject.GetComponent(SmoothFollow).enabled=true;
gameObject.GetComponent(SmoothFollow).target=right;
}
if(Input.GetKeyDown(KeyCode.F)){
++i;
if(i==4){
i=0;
}
}
}
function OnGUI() {
if( GUI.Button(Rect(Screen.width-(Screen.width/6),Screen.height/2-80,60,30),"Heli"))
{
++i;
if(i==4){
i=0;
}
}


}
