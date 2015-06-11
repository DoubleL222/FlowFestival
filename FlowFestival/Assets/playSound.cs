using UnityEngine;
using System.Collections;
public class playSound : MonoBehaviour {
	public AudioClip mySound;
	public AudioSource mySource;
	public float myVolume = 1.0f;

	void Start() {
	}
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Smeti") {
			mySource.Play ();
		}
	}

}