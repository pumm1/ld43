using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		var rigidBody = collider.gameObject.transform.GetComponent<Rigidbody2D>();
		rigidBody.mass = 10; 
		rigidBody.drag = 10;
		rigidBody.gravityScale = 1;
		rigidBody.angularDrag = 5;
		if (collider.tag == "Player")
		{
			Debug.Log("Player DIED! NOOOOOOOOOOO!");
			return;
		}
	}
}
