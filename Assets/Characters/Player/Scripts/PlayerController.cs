
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	private CharacterMovement characterMovement;
	
	void Awake ()
	{
		Cursor.visible = false;
		
		characterMovement = GetComponent<CharacterMovement>();
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));			
		}
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			characterMovement.Jump();
		}
	}

	void FixedUpdate()
	{
		float h = 0;
		
		if (
			Input.GetKey(KeyCode.A) || 
			Input.GetKey(KeyCode.LeftArrow)
		)
		{
			h -= 1.0f;
		}
		if (
			Input.GetKey(KeyCode.D) || 
			Input.GetKey(KeyCode.RightArrow)
		)
		{
			h += 1.0f;
		}

		characterMovement.horizontalMovement = h;
		
		if (Mathf.Abs(h) < Mathf.Epsilon) 
		{
			characterMovement.Brake();
		}		
	}	
}
