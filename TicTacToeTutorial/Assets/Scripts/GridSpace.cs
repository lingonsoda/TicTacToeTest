using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

	public Button button;
	public Text buttonText;
	public Image saturn;
	public Image moon;

	private GameController gameController;

	public void SetGameControllerReference (GameController controller)
	{
		gameController = controller;
	}

	public void SetSpace ()
	{
		buttonText.text = gameController.GetPlayerSide ();
		if (gameController.GetPlayerSide () == "X") {
			saturn.enabled = true;
		}
		if (gameController.GetPlayerSide () == "O") {
			moon.enabled = true;
		}
		button.interactable = false;
		gameController.EndTurn ();
	}

}
