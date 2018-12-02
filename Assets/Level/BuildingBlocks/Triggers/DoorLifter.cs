using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLifter : MonoBehaviour
{
	
	public GameObject targetObject;
	private Rigidbody2D targetRigidBody;

	void Start ()
	{
		targetRigidBody = targetObject.GetComponent<Rigidbody2D>();
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag != "Player")
		{
			return;
		}
		targetRigidBody.gravityScale = -1;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag != "Player")
		{
			return;
		}
		targetRigidBody.gravityScale = 1;
	}


	// Update is called once per frame
	void Update () {
		
	}
}
