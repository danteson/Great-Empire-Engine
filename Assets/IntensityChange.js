function Update () {

if(Input.GetKey("o")) {
GetComponent.<Light>().intensity -= 0.01;
	}
	if(Input.GetKey("l")) {
GetComponent.<Light>().intensity += 0.01;
	}
}