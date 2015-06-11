using UnityEngine;
using System.Collections;

public class FreezeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

/*	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Smeti") {
			col.gameObject.tag = "Frozen";
			col.rigidbody.velocity = Vector3.zero;
			col.rigidbody.angularVelocity = Vector3.zero;
		}
	}
	void OnCollisionExit(Collision col){
		if (col.gameObject.tag == "Frozen") {
			col.gameObject.tag = "Smeti";
		}
	}*/

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Smeti") {
			col.gameObject.tag = "Frozen";
			col.attachedRigidbody.velocity = Vector3.zero;
			col.attachedRigidbody.angularVelocity = Vector3.zero;
		}
	}
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Frozen") {
			col.gameObject.tag = "Smeti";
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
