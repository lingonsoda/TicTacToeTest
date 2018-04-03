﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuController: MonoBehaviour {

	public static MenuController menuController;

	private void Start()
	{
		menuController = this;
	}

	public void ToPlayScene()
	{
		SceneManager.LoadScene("Menu");
	}
}