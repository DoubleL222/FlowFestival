using UnityEngine;
using System.Collections;

public class PullToPoint : MonoBehaviour {
	public bool hasSmet = false;
	public float sphereSize = 1.5f;
	public float speed = 10;
	public GameObject smet;
	// Use this for initialization
	void Start () {
		smet = null;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!hasSmet) {
			smet = null;
			//Collider[] hitColliders = Physics.OverlapSphere (transform.position, sphereSize);
			GameObject[] smeti = GameObject.FindGameObjectsWithTag("Smeti");
			if(smeti.Length>0){
				int index = (int)(Random.Range (0, smeti.Length - 1));

				smet = smeti [index];
				smet.tag = "Locked";
				hasSmet = true;
				Rigidbody rb = smet.GetComponent<Rigidbody>();
				rb.useGravity = false;
				/*while(!hasSmet){
					int index = (int)(Random.Range (0, hitColliders.Length - 1));
					smet = hitColliders [index].gameObject;
				//	if(smeti.Length>0){
					if(hitColliders.Length>0){
					//	int index = (int)(Random.Range (0, smeti.Length - 1));
					//	smet = smeti [index];
						if(smet.tag == "Smeti"){
							smet.tag = "Locked";
							hasSmet = true;
						}
					}
				}*/
				//}
			}
		} else {
			/*Rigidbody rb = smet.GetComponent<Rigidbody>();
			rb.useGravity = false;*/
			float step = speed * Time.deltaTime;
			smet.transform.position = Vector3.MoveTowards (smet.transform.position, transform.position, step);
		}
	}
}
