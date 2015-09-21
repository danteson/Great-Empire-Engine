static var curHealth : int = 100;
static var maxHealth : int = 100;

static var curExp : int = 0;
var maxExp : int = 100;
var xptext : GUIText;
static var level : int = 1;

static var minAttack : int = 500;
static var maxAttack : int = 750;
static var attackPower : int = 6;


var healthtext : GUIText;


function Start () {




healthRegen();

}




function Update () {




healthtext.text = "HP " + curHealth + " / " + maxHealth;
xptext.text = "Level " + level + " XP " + curExp + " / " + maxExp;


if (curExp > maxExp) {
maxExp = maxExp * 1.5;
curExp = 0;
level += 1;
curHealth = maxHealth;
maxHealth = maxHealth * 1.1;
}

if(curHealth < 0 ) {

curHealth = 0;

}

if(curHealth > maxHealth) {

curHealth = maxHealth;

}

}

function healthRegen () {


for(i=1;i>0;i++) {



yield WaitForSeconds(1);

if(curHealth < maxHealth) {

curHealth++;

}


}


}

