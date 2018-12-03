
using Boo.Lang;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public GameObject robot;
	
	private CharacterMovement characterMovement;
	private LimbDropper limbDropper;

	private Animator robotAnimator;
	
	void Awake ()
	{
		Cursor.visible = false;
		
		characterMovement = GetComponent<CharacterMovement>();
		limbDropper = GetComponent<LimbDropper>();
		robotAnimator = robot.GetComponent<Animator>();
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);			
		}
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			characterMovement.Jump();
		}

		if (Input.GetKeyDown(KeyCode.F))
		{
			limbDropper.dropHead();
		}
		if (Input.GetKeyDown(KeyCode.G))
		{
			limbDropper.dropHand();
		}		
		if (Input.GetKeyDown(KeyCode.H))
		{
			limbDropper.dropLeg();
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
		if (
			Input.GetKey(KeyCode.S) || 
			Input.GetKey(KeyCode.DownArrow)
		)
		{
			h *= 0.5f;
		}

		var shouldPlayWalkAnim = Mathf.Abs(h) > Mathf.Epsilon;	                     
		robotAnimator.SetBool("shouldWalk", shouldPlayWalkAnim);                 
		
		characterMovement.horizontalMovement = h;
		
		if (Mathf.Abs(h) < Mathf.Epsilon) 
		{
			characterMovement.Brake();
		}		
	}	
}
