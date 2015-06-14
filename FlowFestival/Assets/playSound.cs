using UnityEngine;
using System.Collections;
public class playSound : MonoBehaviour {
	public AudioSource mySource;

	void Start() {
	}
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Smeti") {
			//mySource.Play ();
			AudioSource audio = col.gameObject.GetComponent<AudioSource>();
			if(audio != null){ audio.Play();}
		}
	}

}