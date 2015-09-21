 var PlayerMode : int = 0; // 0 = Hunter, 1 = Hunted

var Dima : GameObject;
var Marcel : GameObject;

function Start () {

if (!GetComponent.<NetworkView>().isMine) {
			this.enabled = false;
		}}

function Update () {

var viewID : NetworkViewID = Network.AllocateViewID();
 
 GetComponent.<NetworkView>().RPC("SetPlayerMode", RPCMode.AllBuffered, viewID, PlayerMode);
 
 if(GetComponent.<NetworkView>().isMine && Input.GetKeyDown ("0")){
 GetComponent.<NetworkView>().RPC("SetPlayerMode", RPCMode.AllBuffered, viewID, 0);
 }
 
 if(GetComponent.<NetworkView>().isMine && Input.GetKeyDown ("9")){
 GetComponent.<NetworkView>().RPC("SetPlayerMode", RPCMode.AllBuffered, viewID, 1);
 }
}

 @RPC
 function SetPlayerMode (viewID : NetworkViewID, Mode : int) {
  var nView : NetworkView;
  PlayerMode = Mode;
    
 if(PlayerMode == 0){
 Dima.gameObject.active = false;
 Marcel.gameObject.active = true;
 nView = Marcel.GameObject();
 nView.viewID = viewID;
 }
 if(PlayerMode == 1){
 Dima.gameObject.active = true;
 Marcel.gameObject.active = false;
 nView = Dima.GameObject();
 nView.viewID = viewID;
 }
     }
