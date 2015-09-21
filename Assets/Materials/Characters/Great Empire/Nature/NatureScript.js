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

var displayDamage : GUIText;
var enemyHealthText : GUIText;
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


if (MarcelFollow == true) {
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
EspawnPts(randomDamage,0.3,0.4);
spawnBlock();
	}
	else if (Distance < hit && HitCooldown == false && Blocking == true)
	{
		HitCooldown = true;
		anim.SetBool("EnemyHit1",true);
		BlockedHittingCooldown ();
		EspawnPts(0,0.3,0.4);
	}
	else { anim.SetBool("EnemyHit1",false); }
}

enemyHealthText.text = "Enemy HP " + enemyHealth;

if(this.enemyHealth <= 0) {
PlayerHealth.curExp += MobExp;
Destroy(this);
Destroy(this.gameObject,10);
}


}


function OnTriggerStay (col : Collider) {

if(col.gameObject.tag == "attackArea") {

if(Input.GetKeyDown("1") && PlayerHitCooldown == false && Blocking != true) {

PlayerHitCooldown = true;
PlayerHittingCooldown ();
var randomDamage = Random.Range(PlayerHealth.minAttack,PlayerHealth.maxAttack) * PlayerHealth.attackPower;
this.enemyHealth -=randomDamage;
displayDamage.text = "Damage " + randomDamage;
spawnPts(randomDamage,0.3,0.4);



}





}

}

var ptsPrefab: Transform; // drag the prefab to this variable in Inspector

function spawnPts(points: float, x: float, y: float){
    x = Mathf.Clamp(x,0.35,0.95); // clamp position to screen to ensure
    y = Mathf.Clamp(y,0.05,0.9);  // the string will be visible
    var gui: Transform = Instantiate(ptsPrefab,Vector3(x,y,0),Quaternion.identity);
    gui.GetComponent.<GUIText>().text = points.ToString();
    gui.GetComponent.<GUIText>().material.color = Color(1,1,1,1.0);
    }
    
function PlayerHittingCooldown () {
for (var x = 1; x < 2; x++) {
yield WaitForSeconds(0.7);
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
function EspawnPts(points: float, x: float, y: float){
	var DmgDis = Random.Range(minDmgDis,maxDmgDis);
    x = Mathf.Clamp(x,DmgDis,0.95); // clamp position to screen to ensure
    y = Mathf.Clamp(y,0.05,0.9);  // the string will be visible
    var gui: Transform = Instantiate(EptsPrefab,Vector3(x,y,0),Quaternion.identity);
    gui.GetComponent.<GUIText>().text = points.ToString();
    gui.GetComponent.<GUIText>().material.color = Color(1,1,1,1.0);
    }
    
function OnMouseOver() {
	if(Input.GetKeyDown("0") && MarcelEnemy == false) {
	MarcelEnemy = true;
	}
	else if(Input.GetKeyDown("0") && MarcelEnemy == true) {
	MarcelEnemy = false;
	}
	
	if(Input.GetKeyDown("9") && MarcelFollow == false) {
	MarcelFollow = true;
	}
	else if(Input.GetKeyDown("9") && MarcelFollow == true) {
	MarcelFollow = false;
	
	}
}

function spawnBlock () {
   	var randomRotation = Quaternion.Euler( Random.Range(0, 360) , 0 , 0);
     Instantiate(block,node1.transform.position,randomRotation);
 }