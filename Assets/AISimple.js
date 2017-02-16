var Distance;
var Target: Transform;


 var Player : Transform;
 var MoveSpeed = 4;
 var MaxDist = 10;
 var MinDist = 5;
 
 
 
 
 function Start () 
 {
 
 }
 
 function Update () 
 {
     transform.LookAt(Player);
     
     if(Vector3.Distance(transform.position,Player.position) >= MinDist){
     
          transform.position += transform.forward*MoveSpeed*Time.deltaTime;
 
           
           
          if(Vector3.Distance(transform.position,Player.position) <= MaxDist)
              {
              //function lookAt();
{
	//	var rotation = Quaternion.LookRotation(Target.position - transform.position);
			//transform.rotation = Quaternion.Slerp(transform.roation,rotation,Time.deltaTime*Damping);
}

//function attack();
//{
	//transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
//}
    }
 }
 	}