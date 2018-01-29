#pragma strict

var speedometer_main_tex:Texture2D;
	var speedometer_needle_tex:Texture2D;

	private var speedometer_main_rect:Rect;
	private var speedometer_needle_rect:Rect;

	var needle_pivot:Vector2;

	var needle_angle:float = 0; // Should always be 0
	var zero_angle:float = -130; // zero_angle is the angle of the needle, when the vehicle is not moving 
	var speed_add_value:float = 1; // This is how much the needle will move in degress for each kilometer;
	var speed:float; // Current speed
	private var Helifin:helifin;
	
function Start () {

}
function Awake() {
Helifin=gameObject.GetComponent(helifin);

}
function Update () {
speed=Helifin.altitude;
}
function OnGUI() {

		// Calculate the desired rects and the GUI size
		var speedometer_main_size:float = (0.512f * ((Screen.height / 3.5f) + (Screen.width / 3.5f)))/2;
		var speedometer_needle_sizeX:float = ((Screen.height / 110f) + (Screen.width / 110f))/2;
		var speedometer_needle_sizeY:float = ((Screen.height / 30f) + (Screen.width / 30f))/2;

		speedometer_main_rect = Rect( speedometer_needle_sizeX, Screen.height-speedometer_main_size, speedometer_main_size, speedometer_main_size);
		speedometer_needle_rect = Rect(speedometer_needle_sizeX + (speedometer_main_size / 2)-speedometer_needle_sizeX/2 ,
		                                   Screen.height - (speedometer_main_size / 2) - (speedometer_needle_sizeY),
		                                   speedometer_needle_sizeX, speedometer_needle_sizeY);

		// Pivot rotation Vector2
		needle_pivot = Vector2(speedometer_needle_rect.x + (speedometer_needle_sizeX / 2), speedometer_needle_rect.y +(speedometer_needle_sizeY));

		// Draw the speedometer
		GUI.DrawTexture(speedometer_main_rect, speedometer_main_tex);

		//Get the speed of the vehicle


		// zero_angle is the angle of the needle, when the vehicle is not moving
		needle_angle = zero_angle + speed * speed_add_value;

		// Backup the GUI Matrix
	      var matrixBackup:Matrix4x4 = GUI.matrix;

		// Do the actual rotation of the needle
		GUIUtility.RotateAroundPivot(needle_angle, needle_pivot);

		// Draw the needle
		GUI.DrawTexture(speedometer_needle_rect, speedometer_needle_tex);
		GUI.matrix = matrixBackup;

	}