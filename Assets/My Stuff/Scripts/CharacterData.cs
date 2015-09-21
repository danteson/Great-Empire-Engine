/// <summary>
/// This script is used for storing data about the character.
/// If a new variable is made, make sure to add both setters and getters for said variables.
/// This Script Does not need to be added to any component.
/// </summary>
using UnityEngine;
using System.Collections;

public class CharacterData {
	//Simple dataholder for the name.
	private static string cName;

	//Simple getter used to Get the Entered Name.
	//Can be used for Chat system, or above head name display.
	public static string GetName(){
		return cName;
	}

	//Simple setter used to Set the Entered Name
	//Used only for Entering your Name.
	public void SetName(string enteredName){
		cName = enteredName;
	}
}
