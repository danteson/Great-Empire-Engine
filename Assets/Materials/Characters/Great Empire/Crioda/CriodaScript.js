var Distance ;
var Target : Transform;
var anim : Animator;

var lookAtDistance = 25.0;
var attackRange = 15.0;
var hitRange = 2;
var moveSpeed = 5.0;
var Damping = 6;
var hit = 2;
var EnemyminAttack : int = 1;
var EnemymaxAttack : int = 2;
var EnemyattackPower : int = 1;
var MobExp = 10;
var enemyHealth : int = 100;


var minDmgDis = 0.50;
var maxDmgDis = 0.60;

var HitCooldown : boolean = false;
var PlayerHitCooldown : boolean = false;
var hitCD = 0.5;
var blockedHitCD = 2.5;
static var Blocking = false;
var MarcelEnemy = false;
var MarcelFollow = false;

var node1 : Transform;
var block : GameObject;









function Start () {

anim = GetComponent("Animator");
}
Target = GameObject.FindWithTag("Player").transform;

function Update () {

var controller : CharacterController = GetComponent(CharacterController);

if (MarcelFollow == true) {
transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * moveSpeed);
	
	
	lookAt();
	
	
	
	
		
	
}

if (MarcelEnemy == true) {
if(Input.GetKey("2")) { Blocking = true; } else { Blocking = false; }

	Distance = Vector3.Distance(Target.position, transform.position);
	
	if (Distance < lookAtDistance)
	{
	lookAt();
	}
	
	
	if (Distance < attackRange && Distance > hitRange)
	{
		attack ();
		anim.SetBool("Running",true);
	}
	else {anim.SetBool("Running",false);}
	
	if (Distance < hit && HitCooldown == false && Blocking != true)
	{
		HitCooldown = true;
		HittingCooldown ();
		anim.SetBool("EnemyHit1",true);
		var randomDamage = Random.Range(EnemyminAttack,EnemymaxAttack) * EnemyattackPower;
PlayerHealth.curHealth -=randomDamage;
spawnBlock();
	}
	else if (Distance < hit && HitCooldown == false && Blocking == true)
	{
		HitCooldown = true;
		anim.SetBool("EnemyHit1",true);
		BlockedHittingCooldown ();
	}
	else { anim.SetBool("EnemyHit1",false); }
}



}



function OnTriggerStay (col : Collider) {

if(col.gameObject.tag == "attackArea") {

if(Input.GetKeyDown("1") && PlayerHitCooldown == false && Blocking != true) {

PlayerHitCooldown = true;
PlayerHittingCooldown ();
var randomDamage = Random.Range(PlayerHealth.minAttack,PlayerHealth.maxAttack) * PlayerHealth.attackPower;
this.enemyHealth -=randomDamage;



}





}

}

var ptsPrefab: Transform; // drag the prefab to this variable in Inspector

    
function PlayerHittingCooldown () {
for (var x = 1; x < 2; x++) {
yield WaitForSeconds(0.1);
PlayerHitCooldown = false;
}
}


function lookAt ()
{
	
	transform.LookAt(Vector3(Target.position.x, Target.position.y, Target.position.z));
}

function attack ()

{
	transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
}

function HittingCooldown () {
for (var x = 1; x < 2; x++) {
yield WaitForSeconds(hitCD);
HitCooldown = false;
}
}

function BlockedHittingCooldown () {
for (var x = 1; x < 2; x++) {
yield WaitForSeconds(blockedHitCD);
HitCooldown = false;
}
}

var EptsPrefab: Transform; // drag the prefab to this variable in Inspector

    
function OnMouseOver() {
	if(Input.GetKeyDown("5") && MarcelEnemy == false) {
	MarcelEnemy = true;
	}
	else if(Input.GetKeyDown("5") && MarcelEnemy == true) {
	MarcelEnemy = false;
	}
	
	if(Input.GetKeyDown("6") && MarcelFollow == false) {
	MarcelFollow = true;
	}
	else if(Input.GetKeyDown("6") && MarcelFollow == true) {
	MarcelFollow = false;
	
	}
}

function spawnBlock () {
   	var randomRotation = Quaternion.Euler( Random.Range(0, 360) , 0 , 0);
     Instantiate(block,node1.transform.position,randomRotation);
 }