﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MenuController: MonoBehaviour {

	public static MenuController menuController;

	private void Start()
	{
		menuController = this;
	}

	public void ToPlayScene()
	{
		SceneManager.LoadScene("Main");
	}

    public void ExitGame()
    {
        Application.Quit();
    }




}