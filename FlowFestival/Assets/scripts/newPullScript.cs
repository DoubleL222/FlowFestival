using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class newPullScript : MonoBehaviour {
	public int smetiNaMagnet = 5;
//	private List<GameObject> smeti;
	public float sphereSize = 1.5f;
	public float speed = 1;
	// Use this for initialization
	void Start () {
//		smeti = new List<GameObject> ();
		//Destroy (gameObject, dur);
	}
	
	// Update is called once per frame
	//public Transform target;

	void FixedUpdate() {
		Collider[] hitColliders = Physics.OverlapSphere(transform.position,sphereSize);
		int i = 0;
		//List<Collider> myList = hitColliders.ToList();
		foreach(Collider currSmet in hitColliders ){
			if(currSmet.gameObject.tag =="Smeti"){
		//	Collider currSmetCol = currSmet.GetComponent<Collider>();
			//if(!(Vector3.Distance(transform.position, currSmet.gameObject.transform.position)<=1))
			//{
			//if(hitColliders.
				currSmet.attachedRigidbody.useGravity = false;
				float step = speed * Time.deltaTime;
				currSmet.gameObject.transform.position = Vector3.MoveTowards(currSmet.transform.position, transform.position, step);
			}
			//}
		}
		
	}
	void OnTriggerEnter(Collider col)
	{
	/*	if (smeti.Count <= smetiNaMagnet) {
			if (col.gameObject.tag == "Smeti") {
				if (col.attachedRigidbody) {
					col.attachedRigidbody.useGravity=false;
					smeti.Add (col.gameObject);
					//col.attachedRigidbody.MovePosition(transform.position);
				}
			}
		}*/
	}
	void OnTriggerExit(Collider col)
	{
		Debug.Log ("EXITED TRIGGER");
		col.attachedRigidbody.useGravity = true;
	}
}
