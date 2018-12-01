using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrossSceneManagers
{
	public class DoNotDestroyOnLoad : MonoBehaviour 
	{
		void Awake () 
		{		
			DontDestroyOnLoad (gameObject);
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
		}
	}	
}