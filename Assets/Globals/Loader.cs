﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour 
{
	void Awake () 
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}	
}
