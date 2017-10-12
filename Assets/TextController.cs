using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {cell, mirror_0, sheets, door_0, cell_key, mirror_1, door_1, corridor_0, floor, stairs_0, closet,
						corridor_1, stairs_1, in_closet, corridor_2, stairs_2, corridor_3, courtyard};
	private States currentState;

	// Use this for initialization
	void Start () {
		text.text = "Press Space to start the game!";
		currentState = States.cell;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (currentState == States.cell) {
			cell ();
		} else if (currentState == States.sheets) {
			sheets ();
		} else if (currentState == States.door_0) {
			door_0 ();
		} else if (currentState == States.mirror_0) {
			mirror_0 ();
		} else if (currentState == States.cell_key) {
			cell_key ();
		} else if (currentState == States.door_1) {
			door_1 ();
		} else if (currentState == States.mirror_1) {
			mirror_1 ();
		} else if (currentState == States.corridor_0) {
			corridor_0 ();
		} else if (currentState == States.stairs_0) {
			stairs_0 ();
		} else if (currentState == States.closet) {
			closet ();
		} else if (currentState == States.floor) {
			floor ();
		} else if (currentState == States.corridor_1) {
			corridor_1 ();
		} else if (currentState == States.stairs_1) {
			stairs_1 ();
		} else if (currentState == States.in_closet) {
			in_closet ();
		} else if (currentState == States.corridor_2) {
			corridor_2 ();
		} else if (currentState == States.courtyard) {
			courtyard ();
		}
	}

	#region StateHandling
	void cell()
	{
		text.text = "You find yourself locked into a prison cell. " +
					"A mirror is located to your right and a bed covered by dirty sheets is located to your left. " +
					"You are facing the locked door. \n\n" +
					"(Press S to view Sheets, Press M to view Mirror, Press D to view Door.)";
		if (Input.GetKeyDown(KeyCode.S)) {
			currentState = States.sheets;
		}
		else if (Input.GetKeyDown(KeyCode.M)) {
			currentState = States.mirror_0;
		}
		else if (Input.GetKeyDown(KeyCode.D)) {
			currentState = States.door_0;
		}
	}

	void sheets ()
	{
		text.text = "You find the terrible stench is coming from the dirty sheets. " +
		"Besides stinking, they aren't of good use. \n\n" +
		"(Press I to investigate under the sheets. Press R to return to your cell investigation.)";
		if (Input.GetKeyDown (KeyCode.R)) {
			currentState = States.cell;
		} else if (Input.GetKeyDown (KeyCode.I)) {
			currentState = States.cell_key;	
		}
	}

	void door_0()
	{
		text.text = "This door is locked. Maybe there's something around here that can help you open it. \n\n" +
					"(Press R to return to your cell investigation.)";
		if (Input.GetKeyDown(KeyCode.R)) {
			currentState = States.cell;
		}
	}

	void mirror_0 ()
	{
		text.text = "You look pretty handsome for a new guy at a prison. \n\n" +
					"(Press R to return to your cell investigation.)";
		if (Input.GetKeyDown(KeyCode.R)) {
			currentState = States.cell;
		}
	}

	void cell_key ()
	{
		text.text = "You found a key under the dirty sheets! You may now be able to escape!\n\n" +
					"(Press M to view Mirror, Press D to view Door.)";
		if (Input.GetKeyDown(KeyCode.M)) {
			currentState = States.mirror_1;
		}
		else if (Input.GetKeyDown(KeyCode.D)) {
			currentState = States.door_1;
		}
	}

	void door_1 ()
	{
		text.text = "This door is locked. Maybe this key can open it. \n\n" +
		"(Press O to open the door. Press R to return to your cell investigation.)";
		if (Input.GetKeyDown (KeyCode.R)) {
			currentState = States.cell_key;
		} else if (Input.GetKeyDown (KeyCode.O)) {
			currentState = States.corridor_0;
		}
	}

	void mirror_1 ()
	{
		text.text = "You look pretty handsome for a new escaping artist. \n\n" +
					"(Press R to return to your cell investigation.)";
		if (Input.GetKeyDown(KeyCode.R)) {
			currentState = States.cell_key;
		}
	}

	void corridor_0 ()
	{
		text.text = "You are now in the prison corridor.\n" +
					"There are stairs to the courtyard, and a closet to your right.\n\n" +
					"(Press S to view Stairs. Press F to view Floor. Press C to view Closet.)";
		if (Input.GetKeyDown(KeyCode.S)) {
			currentState = States.stairs_0;
		}else if (Input.GetKeyDown(KeyCode.F)) {
			currentState = States.floor;
		}else if (Input.GetKeyDown(KeyCode.C)) {
			currentState = States.closet;
		}
	}

	void stairs_0 ()
	{
		text.text = "Everyone will recognize you if you don't change your clothes before walking in the courtyard.\n\n" +
					"(Press R to return to the corridor.)";
		if (Input.GetKeyDown(KeyCode.R)) {
			currentState = States.corridor_0;
		}
	}

	void closet ()
	{
		text.text = "The closet has a lock that can be picked with the right tool.\n\n" +
					"(Press R to return to the corridor.)";
		if (Input.GetKeyDown(KeyCode.R)) {
			currentState = States.corridor_0;
		}
	}

	void floor ()
	{
		text.text = "There is a hairclip on the floor, close to the left wall.\n\n" +
		"(Press T to take Hairclip. Press R to return to the corridor.)";
		if (Input.GetKeyDown (KeyCode.R)) {
			currentState = States.corridor_0;
		} else if (Input.GetKeyDown (KeyCode.T)) {
			currentState = States.corridor_1;
		}
	}

	void corridor_1 ()
	{
		text.text = "Equipped with a hairclip, you now wonder what you should do in order to escape.\n\n" +
					"(Press S to view Stairs. Press C to view Closet.)";
		if (Input.GetKeyDown(KeyCode.S)) {
			currentState = States.stairs_1;
		}else if (Input.GetKeyDown(KeyCode.C)) {
			currentState = States.in_closet;
		}
	}

	void stairs_1 ()
	{
		text.text = "Everyone will still recognize you if you don't change your clothes before walking in the courtyard, even " +
					"if you are holding a hairclip in your hand.\n\n" +
					"(Press R to return to the corridor.)";
		if (Input.GetKeyDown(KeyCode.R)) {
			currentState = States.corridor_1;
		}
	}

	void in_closet ()
	{
		text.text = "You opened the closet with the hairclip. You now have the option to change your clothes.\n\n" +
					"(Press D to Dress yourself. Press R to return to the corridor.)";
		if (Input.GetKeyDown (KeyCode.R)) {
			currentState = States.corridor_1;
		} else if (Input.GetKeyDown (KeyCode.D)) {
			currentState = States.corridor_2;
		}
	}

	void corridor_2 ()
	{
		text.text = "You are now ready to escape through the stairs.\n\n" +
					"(Press S to take the Stairs to the Courtyard.)";
		if (Input.GetKeyDown (KeyCode.S)) {
			currentState = States.courtyard;
		}
	}

	void courtyard ()
	{
		text.text = "You are now free!!!! Congratulations!!!\n\n" +
					"(Press P to Play again!)";
		if (Input.GetKeyDown (KeyCode.P)) {
			currentState = States.cell;
		}
	}
	#endregion
}
