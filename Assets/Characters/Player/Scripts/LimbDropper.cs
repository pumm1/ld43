using System;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;


public class LimbDropper : MonoBehaviour
{
	public Transform head;
	public List<Transform> hands;
	public List<Transform> legs;

	public Collider2D headCollider;
	public Collider2D legsCollider;
	
	public void start()
	{	
	}
	
	public void dropHead()
	{
		if (head)
		{
			headCollider.enabled = false;
			dropLimb(head);
			head = null;
		}
	}
	
	public void dropHand()
	{
		dropLimb(hands);		
	}
	
	public void dropLeg()
	{
		dropLimb(legs);
		
		if (legs.Count <= 0)
		{	
			legsCollider.enabled = false;	
		}
	}

	public void dropLimb(List<Transform> limbs)
	{
		if (limbs.Count <= 0)
		{		
			return;
		}

		var limb = limbs[0]; 
		dropLimb(limb);
		
		limbs.RemoveAt(0);
	}
	
	private void dropLimb(Transform limb)
	{
		var levels = GameObject.FindGameObjectsWithTag("Level");

		if (levels.Length != 1)
		{
			throw new Exception("Scene must have exactly one GameObject having tag \"Level\"");
		}

		var level = levels[0].transform;

		limb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		limb.GetComponent<Collider2D>().enabled = true;
		limb.parent = level;
	}
}
