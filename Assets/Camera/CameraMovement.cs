using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject followedObject;
	private Rigidbody2D followedRigidBody;
	private Camera camera;
	// Use this for initialization
	void Start ()
	{
		camera = GetComponent<Camera>();
		followedRigidBody = followedObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		
		var targetCameraPosition = new Vector3(
			followedRigidBody.position.x + followedRigidBody.velocity.x*2f, 
			followedRigidBody.position.y + 4f, 
			- Mathf.Abs(followedRigidBody.velocity.x) - 10f );
		
		var currentCameraPosition = camera.transform.position;
		camera.transform.position += (targetCameraPosition - currentCameraPosition) * Time.deltaTime;
	}
}
