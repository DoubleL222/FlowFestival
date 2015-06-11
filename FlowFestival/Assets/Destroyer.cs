using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	public int count;
	// Use this for initialization
	void Start () {
		count = 0;
	}
	void OnTriggerEnter(Collider col){
		Destroy (col.gameObject);
		count++;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
