﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Player{

	public Image panel;
	public Text text;
	public Button button;
	public Image playerImage;
}

[System.Serializable]
public class PlayerColor{

	public Color panelColor;
}

public class GameController : MonoBehaviour {

	public Text[] buttonList;
	public Image[] buttonImageList;
	public GameObject gameOverPanel;
	public Text gameOverText;
	public Image gameOverSaturn;
	public Image gameOverMoon;
	public GameObject restartButton;
	public Player playerX;
	public Player playerO;
	public PlayerColor activePlayerColor;
	public PlayerColor inactivePlayerColor;
	public GameObject startInfo;
    //public int LoadLevel;

    private string playerSide;
	private int moveCount;

	void Awake()
	{
		SetGameControllerReferenceOnButtons ();
		gameOverPanel.SetActive (false);
		gameOverSaturn.enabled = false;
		gameOverMoon.enabled = false;
		moveCount = 0;
		restartButton.SetActive (false);
	}

	void SetGameControllerReferenceOnButtons()
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList [i].GetComponentInParent<GridSpace> ().SetGameControllerReference (this);
		}
	}

	public void SetStartingSide(string startingSide)
	{
		playerSide = startingSide;
		if (playerSide == "X") {
			SetPlayerColors (playerX, playerO);
		} 
		else 
		{
			SetPlayerColors (playerO, playerX);
		}
		StartGame ();
	}

	void StartGame()
	{
		SetBoardInteractable (true);
		SetPlayerButtons (false);
		startInfo.SetActive (false);
	}

	public string GetPlayerSide()
	{
		return playerSide;
	}

	public void EndTurn()
	{
		moveCount++;

		if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide) {
			GameOver (playerSide);
		} else if (moveCount >= 9) {
			GameOver ("draw");
		} else {
			ChangeSides ();
		}
	}

	void ChangeSides()
	{
		playerSide = (playerSide == "X") ? "O" : "X";
		if (playerSide == "X") 
		{
			SetPlayerColors (playerX, playerO);
		} 
		else 
		{
			SetPlayerColors (playerO, playerX);
		}
	}

	void SetPlayerColors (Player newPlayer, Player oldPlayer)
	{
		newPlayer.panel.color = activePlayerColor.panelColor;
		oldPlayer.panel.color = inactivePlayerColor.panelColor;
	}

	void GameOver(string winningPlayer)
	{
		SetBoardInteractable (false);
		if (winningPlayer == "draw") {
			gameOverText.alignment = TextAnchor.MiddleCenter;
			gameOverText.fontSize = 43;
			SetGameOverText ("It's a Draw!");
			SetPlayerColorsInactive ();
		} else if (winningPlayer == "X") {
			gameOverText.alignment = TextAnchor.MiddleRight;
			gameOverText.fontSize = 75;
			SetGameOverText ("Wins!");
			gameOverSaturn.enabled = true;
		} else {
			gameOverText.alignment = TextAnchor.MiddleRight;
			gameOverText.fontSize = 75;
			SetGameOverText ("Wins!");
			gameOverMoon.enabled = true;
		}
		restartButton.SetActive (true);
	}

	void SetGameOverText(string value)
	{
		
		gameOverPanel.SetActive (true);
		gameOverText.text = value;
	}

	public void RestartGame()
	{
		moveCount = 0;
		gameOverPanel.SetActive (false);
		gameOverSaturn.enabled = false;
		gameOverMoon.enabled = false;
		restartButton.SetActive (false);
		SetPlayerButtons (true);
		SetPlayerColorsInactive ();
		startInfo.SetActive (true);

		for (int i = 0; i < buttonList.Length; i++) 
		{
			buttonList [i].text = "";
		}

		for (int i = 0; i < buttonImageList.Length; i++) 
		{
			buttonImageList [i].enabled = false;
		}
	}

	void SetBoardInteractable (bool toggle)
	{
		for (int i = 0; i < buttonList.Length; i++) 
		{
			buttonList [i].GetComponentInParent<Button> ().interactable = toggle;
		}
	}

	void SetPlayerButtons(bool toggle)
	{
		playerX.button.interactable = toggle;
		playerO.button.interactable = toggle;
	}

	void SetPlayerColorsInactive()
	{
		playerX.panel.color = inactivePlayerColor.panelColor;
		playerO.panel.color = inactivePlayerColor.panelColor;
	}


   

   public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }




}
