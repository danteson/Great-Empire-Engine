using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {
	//This variable is used to call the getters and setters
	private CharacterData cData;
	public GameObject Player;
	private Rect mainMenuRect;
	private float width;
	private float height;

	public GUISkin Box;

	//This variable is when opening new GUI.Windows
	private int windowID = 0;

	//Temporary holder for the user name. Used only to pass on the entered name, for the setter.
	private string cName = "";

#region nameHolders
	//Simple strings to hold the names for the different buttons. Really a matter of lazyness.
	private string start = "Start Game";
	private string options = "Options";
	private string plot = "Plot and Features";
	private string quit = "Quit Game";
	private string back = "Back";
#endregion

	// Use this for initialization
	void Start () {
		width = Screen.width / 5;
		height = Screen.height / 1.5f;
		cData = new CharacterData();

		mainMenuRect = new Rect ((Screen.width / 1.3f) - (width / 5), 20, width, height);
	}

	void OnGUI(){
		//This system is used to easily display which GUI.Window players want to have opened.
		if (windowID == 0)
			GUILayout.Window (0, mainMenuRect, MainMenu, "Main Menu");
		else if (windowID == 1)
			GUILayout.Window (0, mainMenuRect, StartMenu, start);
		else if (windowID == 2)
			GUILayout.Window (0, mainMenuRect, OptionsMenu, options);
		else if (windowID == 3)
			GUILayout.Window (0, mainMenuRect, PlotMenu, plot);
		else if (windowID == 4)
			GUILayout.Window (0, mainMenuRect, CharacterMenu, "Character Creation");
	}

	void MainMenu(int id){
		GUI.skin = Box;
		if (GUILayout.Button (start)) {
			windowID = 1;
			Player.SetActive(true);
		}
		if (GUILayout.Button (options)) {
			windowID = 2;
		}
		if (GUILayout.Button (plot)) {
			windowID = 3;
		}

		GUILayout.FlexibleSpace ();

		if(GUILayout.Button (quit)){
			Application.Quit();
		}
	}

	void StartMenu(int id){
		if (GUILayout.Button ("Character Selection")) {
			windowID = 4;
		}
		
		GUILayout.FlexibleSpace ();

		if(GUILayout.Button (back)){
			windowID = 0;
		}
	}

	void OptionsMenu(int id){
		//Options Code needs to be added here.

		GUILayout.FlexibleSpace ();
		
		if(GUILayout.Button (back)){
			windowID = 0;
		}
	}

	void PlotMenu(int id){
		//Plot and Features needs to be added here.

		GUILayout.FlexibleSpace ();
		
		if(GUILayout.Button (back)){
			windowID = 0;
		}
	}
	
	void CharacterMenu(int id){
		GUILayout.BeginHorizontal ();

		GUILayout.Label ("Name:");

		GUILayout.FlexibleSpace ();

		cName = GUILayout.TextField (cName, GUILayout.Width(width / 2));

		GUILayout.EndHorizontal ();

		if (GUILayout.Button (start)) {
			cData.SetName(cName);
			this.GetComponent<NetworkManager>().enabled = true;
			this.enabled = false;
			RandomDebug();
		}
		
		GUILayout.FlexibleSpace ();
		
		if(GUILayout.Button (back)){
			windowID = 0;
		}
	}

	void RandomDebug(){
		//Used for testing the getter. Simply printing the name that the player wants.
		//Works correctly tho, so can be removed if you like.

		print (CharacterData.GetName ());
	}
}
