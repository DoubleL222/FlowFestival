using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class newPullScript : MonoBehaviour {
	public int smetiNaMagnet = 5;
	private List<GameObject> smeti;
	public float dur= float.MinValue;
	// Use this for initialization
	void Start () {
		smeti = new List<GameObject> ();
		Destroy (gameObject, dur);
	}
	
	// Update is called once per frame
	public Transform target;
	public float speed;
	void Update() {
	//	Collider[] hitColliders = Physics.OverlapSphere(transform.position,0.9f);
		int i = 0;
		//List<Collider> myList = hitColliders.ToList();
		foreach(GameObject currSmet in smeti ){
			Collider currSmetCol = currSmet.GetComponent<Collider>();
			//if(!(Vector3.Distance(transform.position, currSmet.gameObject.transform.position)<=1))
			//{
			//if(hitColliders.
				float step = speed * Time.deltaTime;
				currSmet.transform.position = Vector3.MoveTowards(currSmet.transform.position, transform.position, step);
			//}
		}
		
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
