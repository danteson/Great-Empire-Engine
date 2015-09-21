 var Dima : GameObject;
 var TpForward : Transform;
  var TpBack : Transform;
   var TpLeft : Transform;
    var TpRight : Transform;
     var TpUp : Transform;
 
 function Update () {
 
 
     if (Input.GetKeyDown (KeyCode.Y)) { 
     Dima.transform.position = TpForward.position; 
     }
        if (Input.GetKeyDown (KeyCode.H)) { 
     Dima.transform.position = TpBack.position; 
     }
        if (Input.GetKeyDown (KeyCode.G)) { 
     Dima.transform.position = TpLeft.position; 
     }
        if (Input.GetKeyDown (KeyCode.J)) { 
     Dima.transform.position = TpRight.position; 
     }
        if (Input.GetKeyDown (KeyCode.U)) { 
     Dima.transform.position = TpUp.position; 
     }
 }
