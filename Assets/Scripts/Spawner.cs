using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	//SPAWNERS:
public Transform spawner;
public GameObject Gallant;
public GameObject System;
public GameObject Brian;
public GameObject Worm;
public GameObject Lann;
public GameObject MasterGarlie;
public GameObject Esperada;
public GameObject Kido;
public GameObject Vi;
public GameObject Cleopatra;
public GameObject Mivy;
public GameObject Hymn;
public GameObject Dragon;
public GameObject BlackKatana;
public GameObject Marcel;
public GameObject Proto;
public GameObject Crioda;
public GameObject MC;
public GameObject Soma;
public GameObject Nature;
public GameObject Champion;
public GameObject Metal;
public GameObject Psina;
public GameObject Lizard;
public GameObject Arcane;
public GameObject Baikon;
public GameObject Kris;
public GameObject Master;
public GameObject Crusader;
public GameObject Karl;
public GameObject Legend;
public GameObject Galden;
public GameObject FireKarl;
public GameObject Cain;
public GameObject Archieve;
public GameObject Merchant;
public GameObject Zel;
public GameObject P;
public GameObject Commander;
public GameObject Hans;
public GameObject War;
public GameObject Soul;
public GameObject AstiarWill;
public GameObject Zorro;
public GameObject Yashatura;
public GameObject Gore;
public GameObject Ninja;
public GameObject Gaiden;
public GameObject Lavayakan;
public GameObject Spiren;
public GameObject Syfon;
public GameObject Chu;
public GameObject Bermuda;
public GameObject AquaDragon;
public GameObject ArmoredWarlock;
public GameObject BallSpider;
public GameObject CosmoDragon;
public GameObject DarkPegasusRider;
public GameObject EdenTobi;
	public GameObject Amnesia;
	public GameObject Arcada;
	public GameObject Delar;
	public GameObject Trey;
	public GameObject Violet;
public GameObject ShipJunior;

	public GameObject Wave;
	public GameObject SmallWave;
	public Material SkyboxRedwithplanet;
	public Material SkyboxSpace;
	public Material SkyboxForest;
	public Material SkyboxMountains;

//ELEMENTS
	public GameObject Fire;

	public int gmPanel = 0;
	public GameObject camOffset;

	void Start () {
		if (!GetComponent<NetworkView>().isMine) {
			this.enabled = false;
		}
	}

	void Update () {

		if (Input.GetKeyDown("q")){
			GetComponent<NetworkView>().RPC ("InstantiateWave", RPCMode.AllBuffered);}
		if (Input.GetKeyDown("e")){
			GetComponent<NetworkView>().RPC ("InstantiateSmallWave", RPCMode.AllBuffered);}
		if (Input.GetKeyDown("escape")) {
			gmPanel += 1;
		}
		
		if (gmPanel > 1) {
			gmPanel = 0;
		}
	}

	public string password = "";

	#region GUI
	void OnGUI () {
		if (gmPanel == 1) {
			camOffset.GetComponent<SmoothLookAt>().enabled = false;
			GetComponent<SmoothLookAt>().enabled = false;
			GUI.Box (new Rect (Screen.width / 2.6f, Screen.height / 5,300,400), "GM Panel");
			password = GUI.PasswordField (new Rect (Screen.width / 2.5f, Screen.height / 4,200,20), password, "*"[0], 20);
			
			if (Event.current.keyCode == KeyCode.Return)  {

				if( password == "gallant") {
					GetComponent<NetworkView>().RPC ("InstantiateGallant", RPCMode.AllBuffered);
				}
				if( password == "fire") {
					GetComponent<NetworkView>().RPC ("InstantiateFire", RPCMode.AllBuffered);
				}
				if( password == "system") {
					GetComponent<NetworkView>().RPC ("InstantiateSystem", RPCMode.AllBuffered);}
				if( password == "edentobi") {
					GetComponent<NetworkView>().RPC ("InstantiateEdenTobi", RPCMode.AllBuffered);}
				if( password == "skyredplanet") {
					GetComponent<NetworkView>().RPC ("AssignSkyboxRedwithplanet", RPCMode.AllBuffered);}
				if( password == "skyspace") {
					GetComponent<NetworkView>().RPC ("AssignSkyboxSpace", RPCMode.AllBuffered);}
				if( password == "skyforest") {
					GetComponent<NetworkView>().RPC ("AssignSkyboxForest", RPCMode.AllBuffered);}
				if( password == "skymountains") {
					GetComponent<NetworkView>().RPC ("AssignSkyboxMountains", RPCMode.AllBuffered);}
				if( password == "ballspider") {
					GetComponent<NetworkView>().RPC ("InstantiateBallSpider", RPCMode.AllBuffered);}
				if( password == "aquadragon") {
					GetComponent<NetworkView>().RPC ("InstantiateAquaDragon", RPCMode.AllBuffered);}
				if( password == "cosmodragon") {
					GetComponent<NetworkView>().RPC ("InstantiateCosmoDragon", RPCMode.AllBuffered);}
				if( password == "darkpegasusrider") {
					GetComponent<NetworkView>().RPC ("InstantiateDarkPegasusRider", RPCMode.AllBuffered);}
				if( password == "armoredwarlock") {
					GetComponent<NetworkView>().RPC ("InstantiateArmoredWarlock", RPCMode.AllBuffered);}
				if( password == "brian") {
					GetComponent<NetworkView>().RPC ("InstantiateBrian", RPCMode.AllBuffered);}
				if( password == "worm") {
					GetComponent<NetworkView>().RPC ("InstantiateWorm", RPCMode.AllBuffered);}
				if( password == "lann") {
					GetComponent<NetworkView>().RPC ("InstantiateLann", RPCMode.AllBuffered);}
				if( password == "shipjunior") {
					GetComponent<NetworkView>().RPC ("InstantiateShipJunior", RPCMode.AllBuffered);}
				if( password == "mastergarlie") {
					GetComponent<NetworkView>().RPC ("InstantiateMasterGarlie", RPCMode.AllBuffered);}
				if( password == "esperada") {
					GetComponent<NetworkView>().RPC ("InstantiateEsperada", RPCMode.AllBuffered);}
				if( password == "kido") {
					GetComponent<NetworkView>().RPC ("InstantiateKido", RPCMode.AllBuffered);}
				if( password == "vi") {
					GetComponent<NetworkView>().RPC ("InstantiateVi", RPCMode.AllBuffered);}
				if( password == "amnesia") {
					GetComponent<NetworkView>().RPC ("InstantiateAmnesia", RPCMode.AllBuffered);}
				if( password == "arcada") {
					GetComponent<NetworkView>().RPC ("InstantiateArcada", RPCMode.AllBuffered);}
				if( password == "delar") {
					GetComponent<NetworkView>().RPC ("InstantiateDelar", RPCMode.AllBuffered);}
				if( password == "trey") {
					GetComponent<NetworkView>().RPC ("InstantiateTrey", RPCMode.AllBuffered);}
				if( password == "violet") {
					GetComponent<NetworkView>().RPC ("InstantiateViolet", RPCMode.AllBuffered);}
				if( password == "cleopatra") {
					GetComponent<NetworkView>().RPC ("InstantiateCleopatra", RPCMode.AllBuffered);}
				if( password == "mivy") {
					GetComponent<NetworkView>().RPC ("InstantiateMivy", RPCMode.AllBuffered);}
				if( password == "hymn") {
					GetComponent<NetworkView>().RPC ("InstantiateHymn", RPCMode.AllBuffered);}
				if( password == "dragon") {
					GetComponent<NetworkView>().RPC ("InstantiateDragon", RPCMode.AllBuffered);}
				if( password == "blackkatana") {
					GetComponent<NetworkView>().RPC ("InstantiateBlackKatana", RPCMode.AllBuffered);}
				if( password == "marcel") {
					GetComponent<NetworkView>().RPC ("InstantiateMarcel", RPCMode.AllBuffered);}
				if( password == "proto") {
					GetComponent<NetworkView>().RPC ("InstantiateProto", RPCMode.AllBuffered);}
				if( password == "crioda") {
					GetComponent<NetworkView>().RPC ("InstantiateCrioda", RPCMode.AllBuffered);}
				if( password == "mc") {
					GetComponent<NetworkView>().RPC ("InstantiateMC", RPCMode.AllBuffered);}
				if( password == "soma") {
					GetComponent<NetworkView>().RPC ("InstantiateSoma", RPCMode.AllBuffered);}
				if( password == "nature") {
					GetComponent<NetworkView>().RPC ("InstantiateNature", RPCMode.AllBuffered);}
				if( password == "champion") {
					GetComponent<NetworkView>().RPC ("InstantiateChampion", RPCMode.AllBuffered);}
				if( password == "metal") {
					GetComponent<NetworkView>().RPC ("InstantiateMetal", RPCMode.AllBuffered);}
				if( password == "psina") {
					GetComponent<NetworkView>().RPC ("InstantiatePsina", RPCMode.AllBuffered);}
				if( password == "lizard") {
					GetComponent<NetworkView>().RPC ("InstantiateLizard", RPCMode.AllBuffered);}
				if( password == "arcane") {
					GetComponent<NetworkView>().RPC ("InstantiateArcane", RPCMode.AllBuffered);}
				if( password == "baikon") {
					GetComponent<NetworkView>().RPC ("InstantiateBaikon", RPCMode.AllBuffered);}
				if( password == "kris") {
					GetComponent<NetworkView>().RPC ("InstantiateKris", RPCMode.AllBuffered);}
				if( password == "master") {
					GetComponent<NetworkView>().RPC ("InstantiateMaster", RPCMode.AllBuffered);}
				if( password == "crusader") {
					GetComponent<NetworkView>().RPC ("InstantiateCrusader", RPCMode.AllBuffered);}
				if( password == "karl") {
					GetComponent<NetworkView>().RPC ("InstantiateKarl", RPCMode.AllBuffered);}
				if( password == "legend") {
					GetComponent<NetworkView>().RPC ("InstantiateLegend", RPCMode.AllBuffered);}
				if( password == "galden") {
					GetComponent<NetworkView>().RPC ("InstantiateGalden", RPCMode.AllBuffered);}
				if( password == "firekarl") {
					GetComponent<NetworkView>().RPC ("InstantiateFireKarl", RPCMode.AllBuffered);}
				if( password == "cain") {
					GetComponent<NetworkView>().RPC ("InstantiateCain", RPCMode.AllBuffered);}
				if( password == "archieve") {
					GetComponent<NetworkView>().RPC ("InstantiateArchieve", RPCMode.AllBuffered);}
				if( password == "merchant") {
					GetComponent<NetworkView>().RPC ("InstantiateMerchant", RPCMode.AllBuffered);}
				if( password == "zel") {
					GetComponent<NetworkView>().RPC ("InstantiateZel", RPCMode.AllBuffered);}
				if( password == "p") {
					GetComponent<NetworkView>().RPC ("InstantiateP", RPCMode.AllBuffered);}
				if( password == "commander") {
					GetComponent<NetworkView>().RPC ("InstantiateCommander", RPCMode.AllBuffered);}
				if( password == "hans") {
					GetComponent<NetworkView>().RPC ("InstantiateHans", RPCMode.AllBuffered);}
				if( password == "war") {
					GetComponent<NetworkView>().RPC ("InstantiateWar", RPCMode.AllBuffered);}
				if( password == "soul") {
					GetComponent<NetworkView>().RPC ("InstantiateSoul", RPCMode.AllBuffered);}
				if( password == "astiarwill") {
					GetComponent<NetworkView>().RPC ("InstantiateAstiarWill", RPCMode.AllBuffered);}
				if( password == "lavayakan") {
					GetComponent<NetworkView>().RPC ("InstantiateLavayakan", RPCMode.AllBuffered);}
				if( password == "bermudian") {
					GetComponent<NetworkView>().RPC ("InstantiateBermuda", RPCMode.AllBuffered);}
				if( password == "yashatura") {
					GetComponent<NetworkView>().RPC ("InstantiateYashatura", RPCMode.AllBuffered);}
				if( password == "ninja") {
					GetComponent<NetworkView>().RPC ("InstantiateNinja", RPCMode.AllBuffered);}
				if( password == "gaiden") {
					GetComponent<NetworkView>().RPC ("InstantiateGaiden", RPCMode.AllBuffered);}
				if( password == "zorro") {
					GetComponent<NetworkView>().RPC ("InstantiateZorro", RPCMode.AllBuffered);}
				if( password == "gore") {
					GetComponent<NetworkView>().RPC ("InstantiateGore", RPCMode.AllBuffered);}
				if( password == "chu") {
					GetComponent<NetworkView>().RPC ("InstantiateChu", RPCMode.AllBuffered);}
				if( password == "syfon") {
					GetComponent<NetworkView>().RPC ("InstantiateSyfon", RPCMode.AllBuffered);}
				if( password == "spiren") {
					GetComponent<NetworkView>().RPC ("InstantiateSpiren", RPCMode.AllBuffered);}
				if( password == "tpbrokenland") {
					transform.position = new Vector3 (-1308.851f, 3.070371f, 514.272f);
				}
				if( password == "tpgreatempire") {
					transform.position = new Vector3 (340.1118f, 3.070371f, 168.2979f);
				}
				if( password == "tpcliffdesert") {
					transform.position = new Vector3 (-3205.5f, 4.35f, -2381.2f);
				}
				if( password == "tpforestvillage") {
					transform.position = new Vector3 (-36.77138f, 1.704f, -4564.017f);
				}
				if( password == "tpeden") {
					transform.position = new Vector3 (457.1196f, 866.4693f, 103.7442f);
				}
				if( password == "tpstarspace") {
					transform.position = new Vector3 (-944.2f, 3691.32f, -2963.4f);
				}
				if( password == "tpstepspace") {
					transform.position = new Vector3 (-944.2f, 3051.071f, -2963.4f);
				}
				if( password == "tpmovingspace") {
					transform.position = new Vector3 (3716.044f, -12862.86f, -12516.98f);
				}
				if( password == "tparena") {
					transform.position = new Vector3 (1262.138f, 2.15766f, -74.27048f);
				}
				if( password == "tpbermuda") {
					transform.position = new Vector3 (874.0087f, 15402.99f, 37.15505f);
				}
				if( password == "tpgalandec") {
					transform.position = new Vector3 (2174.669f, 696.1208f, -221.4821f);
				}
				if( password == "tpalaska") {
					transform.position = new Vector3 (-1235.884f, -72.48644f, 30020.93f);
				}
				if( password == "tpscifi") {
					transform.position = new Vector3 (-944.2f, 4186.8f, -2963.4f);
				}
				if( password == "tpinnerworld") {
					transform.position = new Vector3 (-944.2f, 5705.2f, -2963.4f);
				}
				password = string.Empty;
			}
			

		} else {
			camOffset.GetComponent<SmoothLookAt>().enabled = true;
			GetComponent<SmoothLookAt>().enabled = true;
		}
	}
	#endregion
	#region RPC
	[RPC]
	void InstantiateGallant() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Gallant,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateFire() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Fire,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateSystem() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (System,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateCosmoDragon() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (CosmoDragon,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateDarkPegasusRider() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (DarkPegasusRider,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateEdenTobi() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (EdenTobi,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateShipJunior() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (ShipJunior,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void AssignSkyboxRedwithplanet() {
		RenderSettings.skybox=SkyboxRedwithplanet;

	}
	[RPC]
	void AssignSkyboxForest() {
		RenderSettings.skybox=SkyboxForest;
		
	}
	[RPC]
	void AssignSkyboxMountains() {
		RenderSettings.skybox=SkyboxMountains;
		
	}
	[RPC]
	void AssignSkyboxSpace() {
		RenderSettings.skybox=SkyboxSpace;
		
	}
	[RPC]
	void InstantiateArmoredWarlock() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (ArmoredWarlock,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateBallSpider() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (BallSpider,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateAquaDragon() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (AquaDragon,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateBrian() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Brian,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateAmnesia() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Amnesia,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateArcada() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Arcada,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateDelar() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Delar,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateTrey() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Trey,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateViolet() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Violet,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateWorm() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Worm,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateLann() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Lann,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateMasterGarlie() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (MasterGarlie,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateWave() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Wave,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateSmallWave() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (SmallWave,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateEsperada() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Esperada,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateKido() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Kido,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateVi() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Vi,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateCleopatra() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Cleopatra,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateMivy() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Mivy,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateHymn() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Hymn,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateDragon() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Dragon,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateBlackKatana() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (BlackKatana,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateMarcel() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Marcel,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateProto() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Proto,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateCrioda() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Crioda,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateMC() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (MC,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateSoma() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Soma,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateNature() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Nature,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateChampion() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Champion,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateMetal() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Metal,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiatePsina() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Psina,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateLizard() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Lizard,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateArcane() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Arcane,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateBaikon() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Baikon,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateKris() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Kris,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateMaster() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Master,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateCrusader() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Crusader,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateKarl() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Karl,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateLegend() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Legend,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateGalden() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Galden,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateFireKarl() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (FireKarl,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateCain() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Cain,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateArchieve() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Archieve,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateMerchant() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Merchant,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateZel() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Zel,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateP() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (P,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateCommander() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Commander,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateHans() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Hans,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateWar() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (War,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateSoul() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Soul,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateAstiarWill() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (AstiarWill,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateBermuda() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Bermuda,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateLavayakan() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Lavayakan,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateYashatura() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Yashatura,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateGaiden() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Gaiden,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateNinja() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Ninja,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateSpiren() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Spiren,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateSyfon() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Syfon,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateGore() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Gore,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateZorro() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Zorro,spawner.transform.position,transform.rotation, 0);
		}
	}
	[RPC]
	void InstantiateChu() {
		if (GetComponent<NetworkView>().isMine) {
			Network.Instantiate (Chu,spawner.transform.position,transform.rotation, 0);
		}
	}
	#endregion
}
