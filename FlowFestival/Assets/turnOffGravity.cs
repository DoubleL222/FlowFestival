using UnityEngine;
using System.Collections;

public class turnOffGravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void onTriggerExit(Collider col){
		col.attachedRigidbody.useGravity = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
