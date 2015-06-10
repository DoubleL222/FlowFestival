using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelMaker : MonoBehaviour {
	public GameObject levelCube;
	public GameObject wallCube;
	public float cubeSize;
	public float zamik = float.MinValue;
	public float sirina = float.MinValue;
	public GameObject levelFather;
	public Slider smetiSlider;
	public Text smetiText;
	public float sirinaX=5.0f;
	public float dolzinaZ=5.0f;
	public float visinaY=5.0f;
	private int steviloSmeti;
	private float l,w,h;
	public GameObject[] smeti;
	public Canvas meni;

	private bool started;
	// Use this for initialization
	void Start () {
		GameObject center = Instantiate (levelCube, new Vector3(0,cubeSize/2.0f,0),Quaternion.identity) as GameObject;
		GameObject leftWall = Instantiate (wallCube, new Vector3 (-cubeSize / 2.0f - zamik, cubeSize / 2.0f, 0), Quaternion.identity) as GameObject;
		GameObject rightWall = Instantiate (wallCube, new Vector3 (cubeSize / 2.0f + zamik, cubeSize / 2.0f, 0), Quaternion.identity) as GameObject;
		GameObject frontWall = Instantiate (wallCube, new Vector3 (0, cubeSize / 2.0f, cubeSize / 2.0f + zamik), Quaternion.identity) as GameObject;
		GameObject backWall = Instantiate (wallCube, new Vector3 (0, cubeSize / 2.0f, -cubeSize / 2.0f - zamik), Quaternion.identity) as GameObject;
		GameObject topWall = Instantiate (wallCube, new Vector3 (0, 0-zamik, 0), Quaternion.identity) as GameObject;
		GameObject bottomWall = Instantiate (wallCube, new Vector3 (0, cubeSize+zamik, 0), Quaternion.identity) as GameObject;
		leftWall.transform.localScale = new Vector3 (sirina, cubeSize, cubeSize);
		rightWall.transform.localScale = new Vector3 (sirina, cubeSize, cubeSize);
		frontWall.transform.localScale = new Vector3 (cubeSize, cubeSize, sirina);
		backWall.transform.localScale = new Vector3 (cubeSize, cubeSize, sirina);
		topWall.transform.localScale = new Vector3 (cubeSize, sirina, cubeSize);
		bottomWall.transform.localScale = new Vector3 (cubeSize, sirina, cubeSize);
		center.transform.localScale = new Vector3 (cubeSize, cubeSize, cubeSize);
		leftWall.transform.parent = levelFather.transform;
		rightWall.transform.parent = levelFather.transform;
		frontWall.transform.parent = levelFather.transform;
		backWall.transform.parent = levelFather.transform;
		topWall.transform.parent = levelFather.transform;
		bottomWall.transform.parent = levelFather.transform;
		center.transform.parent = levelFather.transform;

		started = false;
	}
	public void updateText(){
		smetiText.text = smetiSlider.value.ToString ();
	}
	public void startLevel(){
		meni.enabled = false;
		steviloSmeti = (int)smetiSlider.value;
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
		if(Input.GetKeyDown(KeyCode.Space)){
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
