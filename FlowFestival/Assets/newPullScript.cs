using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class newPullScript : MonoBehaviour {
	public int smetiNaMagnet = 5;
	private List<GameObject> smeti;
	public float dur= float.MinValue;
	// Use this for initialization
	void Start () {
		smeti = new List<GameObject> ();
	}
	
	// Update is called once per frame
	public Transform target;
	public float speed;
	void Update() {
		foreach(GameObject currSmet in smeti ){
			float step = speed * Time.deltaTime;
			currSmet.transform.position = Vector3.MoveTowards(currSmet.transform.position, transform.position, step);
		}
		Destroy (gameObject, dur);
	}
	void OnTriggerEnter(Collider col)
	{
		if (smeti.Count <= smetiNaMagnet) {
			if (col.gameObject.tag == "Smeti") {
				if (col.attachedRigidbody) {
					col.attachedRigidbody.useGravity=false;
					smeti.Add (col.gameObject);
					//col.attachedRigidbody.MovePosition(transform.position);
				}
			}
		}
	}
}
