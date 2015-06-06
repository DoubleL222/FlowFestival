using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {
	public float sirinaX=5.0f;
	public float dolzinaZ=5.0f;
	public float visinaY=5.0f;
	public int steviloSmeti=5;
	private float l,w,h;
	public GameObject[] smeti;

	// Use this for initialization
	void Start () {
		for (int i=0; i<steviloSmeti; i++) {
			w = Random.Range (-sirinaX / 2, sirinaX / 2);
			l = Random.Range (-dolzinaZ / 2, dolzinaZ / 2);
			h = visinaY;
			int indeks =(int)(Random.Range(0,smeti.Length-1));
			Instantiate(smeti[indeks], new Vector3(w,h,l), Quaternion.identity);
		}

	}
	
	// Update is called once per frame
	void Update () {

	}
}
