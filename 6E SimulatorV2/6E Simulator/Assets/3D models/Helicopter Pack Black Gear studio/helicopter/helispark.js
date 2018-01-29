#pragma strict
   
	var sparksound:AudioClip;
	var FallImpactVel:float=-40;//The negative velocity below which to detect whether player falls from too much height
	var health:int =100;
	var state: boolean =false;
	var rotor :GameObject;
	var DamageFactor:float=1;
	public var mainrotor_axis : int=1;
    var refr:GameObject;
    var distanceToGround:float;
    var particlefire:GameObject;
	var explosion:GameObject;
	var detonator:GameObject;
    private var altitude :float;
    private var Helifin:helifin;
    var textureburn:Texture;
    var normaltexture:Texture;
    var mainmaterial:Material;
    var scorchMark:GameObject;
    var fire:GameObject;
    var hitParticles:GameObject;
   private var deathtimer:float=0;
    private var i:int=0;
    private var Dieingtimer:float=0;
function Awake() {
Helifin=gameObject.GetComponent(helifin);
}

	// Use this for initialization
	function falling()
	{
	deathtimer+=Time.deltaTime;
	if(deathtimer>10){
	explode();
	}
		switch(mainrotor_axis)
		{
		
			case 1:
				rotor.transform.Rotate(1000*Random.value,0,0);
				break;
			case 2:
				rotor.transform.Rotate(0,1000*Random.value,0);
				break;
			case 3:
				rotor.transform.Rotate(0,0,1000*Random.value);
				break;	
				
		}
		GetComponent.<AudioSource>().pitch=Random.Range(0.1,0.6);
        var groundHit:RaycastHit;
        Physics.Raycast(refr.transform.position,-Vector3.up,groundHit);
        altitude=groundHit.distance;
       
        if(altitude<2){
			explode();
			
			
		}
if(Vector3.Angle(refr.transform.up,Vector3.down)<30){
explode();
}



	}
	function explode() //exploding the helicopter and creating d4ecals
	{
	    print ("exploded"+distanceToGround);
		GetComponent.<AudioSource>().Stop();
		GetComponent.<Rigidbody>().AddExplosionForce(427600,transform.position,100);
		Instantiate(detonator,explosion.transform.position,transform.rotation);
	    mainmaterial.mainTexture=textureburn;
	    scorchMark=Instantiate(scorchMark,Vector3.zero,Quaternion.identity);
		var scorchPosition : Vector3 = refr.GetComponent.<Collider>().ClosestPointOnBounds (transform.position - Vector3.up * 100);
		scorchMark.transform.position = scorchPosition + Vector3.up * 1.1;
		scorchMark.transform.eulerAngles.y = Random.Range (0.0, 90.0);
		Destroy (this);
	}
	function Start () 
	{
		particlefire.SetActive(false);
		mainmaterial.mainTexture=normaltexture;
	}
	
	// Update is called once per frame
	function Update () 
	{
	if(GetComponent.<Rigidbody>().velocity.y<FallImpactVel){
     if(Helifin.altitude<2){
			health+=1*GetComponent.<Rigidbody>().velocity.y*DamageFactor;
			}
			}
	
	    if(health<0){
		 state=true;
		 falling ();
		}
		if(health<20){
		 fire.SetActive(true);
		}
	

	    if(state==true){
		 particlefire.SetActive(true);
		}
		
		
		
	}
	 function OnCollisionEnter(other : Collision) { //If colliding above ground

  
		if(Helifin.altitude>2.4) {
				GetComponent.<AudioSource>().PlayOneShot(sparksound);
				health-=20*DamageFactor;
				var contact = other.contacts[0];
		var rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
		var pos = contact.point;
		var mark:GameObject=Instantiate(hitParticles, pos, rot);
               mark.transform.parent=other.collider.transform;
				Dieingtimer=0;
				}
			
			
			
	
	}
	

	function OnCollisionStay(collision : Collision) {
	if(Helifin.altitude>2.4) {
		
		Dieingtimer+=Time.deltaTime;
		if (Dieingtimer>1){
		health-=10*DamageFactor;
		Dieingtimer=0;
		}
		
	 }
 
		
		
				
		
}
	
	 function FixedUpdate() {
	 
				
			
	 
	if(state==true){

			GetComponent.<Rigidbody>().AddRelativeTorque(0,30000,0);
			GetComponent.<Rigidbody>().AddForce(0,-15000,0);
			
		}
	}