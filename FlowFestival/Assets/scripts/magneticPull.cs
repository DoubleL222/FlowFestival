﻿using UnityEngine;
using System.Collections;

public class magneticPull : MonoBehaviour {
	public float expForce=10.0f;
	public float radij=10.0f;
	public float dur= float.MinValue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, dur);
	}
	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Smeti")
		{
			if(col.attachedRigidbody)
			{
				col.attachedRigidbody.AddExplosionForce(- expForce, gameObject.transform.position , radij);
			}
		}
	}
}
