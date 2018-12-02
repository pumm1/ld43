using System;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;


public class LimbDropper : MonoBehaviour
{
	public Collider2D headCollider;
	public Collider2D legsCollider;
	
	public GameObject headToDestroy;
	public GameObject leftHandToDestroy;
	public GameObject rightHandToDestroy;
	public GameObject leftLegToDestroy;
	public GameObject rightLegToDestroy;

	public GameObject headToInstantiate;
	public GameObject leftHandToInstantiate;
	public GameObject rightHandToInstantiate;
	public GameObject leftLegToInstantiate;
	public GameObject rightLegToInstantiate;
//	
	
	public void dropHead()
	{
		if (headToDestroy)
		{
			dropLimb(headToDestroy, headToInstantiate);
			headToDestroy = null;
			headCollider.enabled = false;
		}
	}
	
	public void dropHand()
	{
		if (leftHandToDestroy)
		{
			dropLimb(leftHandToDestroy, leftHandToInstantiate);
			leftHandToDestroy = null;
		}
		else if (rightHandToDestroy)
		{
			dropLimb(rightHandToDestroy, rightHandToInstantiate);
			rightHandToDestroy = null;			
		}
	}
	
	public void dropLeg()
	{
		if (leftLegToDestroy)
		{
			dropLimb(leftLegToDestroy, leftLegToInstantiate);
			leftLegToDestroy = null;
		}
		else if (rightLegToDestroy)
		{
			dropLimb(rightLegToDestroy, rightLegToInstantiate);
			rightLegToDestroy = null;
			legsCollider.enabled = false;
		}
	}
	
	public void dropLimb(GameObject limbToDestroy, GameObject limbToInstantiate)
	{
		var droppedLimb = Instantiate(limbToInstantiate, getLevel());
		droppedLimb.transform.position = limbToDestroy.transform.position;

		droppedLimb.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
		
		Destroy(limbToDestroy);
	}
	
	public Transform getLevel()
	{
		var levels = GameObject.FindGameObjectsWithTag("Level");

		if (levels.Length != 1)
		{
			throw new Exception("Scene must have exactly one GameObject having tag \"Level\"");
		}

		return levels[0].transform;		
	}
}
