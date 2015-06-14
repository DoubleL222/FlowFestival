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
	public int steviloSmetiPrivlek=0;
	private int steviloSmeti;
	private float l,w,h;
	public GameObject[] smeti;
	public Canvas meni;
	public GameObject bottomWallCube;
	public float zamikTal = 2.0f;
	private GameObject[] staticneSmeti;
	public float waitTime;
	private float startTime;
	private bool fixated = false;
	public Slider smetiSliderDin;
	public Text smetiTextDin;

	private bool started;
	// Use this for initialization
	void Start () {
		startTime = 0.0f;
		fixated = false;
		GameObject center = Instantiate (levelCube, new Vector3(0,cubeSize/2.0f,0),Quaternion.identity) as GameObject;
		GameObject leftWall = Instantiate (wallCube, new Vector3 (-cubeSize / 2.0f - zamik, cubeSize / 2.0f, 0), Quaternion.identity) as GameObject;
		GameObject rightWall = Instantiate (wallCube, new Vector3 (cubeSize / 2.0f + zamik, cubeSize / 2.0f, 0), Quaternion.identity) as GameObject;
		GameObject frontWall = Instantiate (wallCube, new Vector3 (0, cubeSize / 2.0f, cubeSize / 2.0f + zamik), Quaternion.identity) as GameObject;
		GameObject backWall = Instantiate (wallCube, new Vector3 (0, cubeSize / 2.0f, -cubeSize / 2.0f - zamik), Quaternion.identity) as GameObject;
		GameObject bottomWall = Instantiate (bottomWallCube, new Vector3 (0, 0-zamikTal, 0), Quaternion.identity) as GameObject;
		GameObject bottomBottomWall = Instantiate (bottomWallCube, new Vector3 (0, 0-2*zamikTal, 0), Quaternion.identity) as GameObject;
		GameObject topWall = Instantiate (wallCube, new Vector3 (0, cubeSize+zamik, 0), Quaternion.identity) as GameObject;
		leftWall.transform.localScale = new Vector3 (sirina, cubeSize, cubeSize);
		rightWall.transform.localScale = new Vector3 (sirina, cubeSize, cubeSize);
		frontWall.transform.localScale = new Vector3 (cubeSize, cubeSize, sirina);
		backWall.transform.localScale = new Vector3 (cubeSize, cubeSize, sirina);
		topWall.transform.localScale = new Vector3 (cubeSize, sirina, cubeSize);
		bottomWall.transform.localScale = new Vector3 (cubeSize*4, sirina, cubeSize*4);
		bottomBottomWall.transform.localScale = new Vector3 (cubeSize*4, sirina, cubeSize*4);
		center.transform.localScale = new Vector3 (cubeSize, cubeSize, cubeSize);
		leftWall.transform.parent = levelFather.transform;
		rightWall.transform.parent = levelFather.transform;
		frontWall.transform.parent = levelFather.transform;
		backWall.transform.parent = levelFather.transform;
		topWall.transform.parent = levelFather.transform;
		bottomWall.transform.parent = levelFather.transform;
		center.transform.parent = levelFather.transform;
		bottomBottomWall.transform.parent = levelFather.transform;

		started = false;
	}
	public void updateText(){
		smetiText.text = smetiSlider.value.ToString ();
	}
	public void updateTextDin(){
		smetiTextDin.text = smetiSliderDin.value.ToString ();
	}
	public void startLevel(){

		meni.enabled = false;

		steviloSmetiPrivlek = (int)smetiSliderDin.value;
		steviloSmeti = (int)smetiSlider.value;
		staticneSmeti = new GameObject[steviloSmeti];
		for (int i=0; i<steviloSmeti; i++) {
			w = Random.Range (-sirinaX / 2, sirinaX / 2);
			l = Random.Range (-dolzinaZ / 2, dolzinaZ / 2);
			h = visinaY;
			int indeks =(int)(Random.Range(0,smeti.Length-1));
			//int indeks = 0;
			GameObject obj = Instantiate(smeti[indeks], new Vector3(w,h,l), Quaternion.identity) as GameObject;
			obj.gameObject.tag="Frozen";
			staticneSmeti[i] = obj;
		}
		for(int i=0; i<steviloSmetiPrivlek; i++) {
			w = Random.Range (-sirinaX / 2, sirinaX / 2);
			l = Random.Range (-dolzinaZ / 2, dolzinaZ / 2);
			h = visinaY;
			int indeks =(int)(Random.Range(0,smeti.Length-1));
			//int indeks = 0;
			GameObject obj = Instantiate(smeti[indeks], new Vector3(w,h,l), Quaternion.identity) as GameObject;
			obj.gameObject.tag="Smeti";
		}
		startTime = Time.time;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			DestroyImmediate(Camera.main.gameObject);
			Application.LoadLevel("TestLevel");

		}
		if (startTime!=0.0f && !fixated && (Time.time - startTime) >= waitTime) {
			Debug.Log ("ZANKA PANKA");
			foreach (GameObject smet in staticneSmeti){
				if(smet != null){
					Rigidbody rb = smet.GetComponent<Rigidbody>();
					Destroy(rb);
					fixated = true;
				}
			}
		}
	}
}
