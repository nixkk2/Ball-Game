using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {


	public GameObject S1;
	public GameObject S2;
	public GameObject floor3;
	private Renderer rend;
	public Color playerColor = Color.white;
	private float timer = 1F;
	private bool time = false;

	void Start () {
		//S1 = GameObject.Find("Grounds/S1");
		//S2 = GameObject.Find("Grounds/S2");
	}
	
	// Update is called once per frame
	void Update () {
		rend = floor3.GetComponent<Renderer>();
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
		if (time) {
			timer = timer * Time.deltaTime;
			playerColor.a = timer / 100;
			if (timer / 100 == 1F)
				time = false;
			rend.material.color = playerColor;
		}
	}


	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			gameObject.SetActive(false);
			if (gameObject.name == "PickUpLvl1") {
				Debug.Log(gameObject.name);
				S2.gameObject.SetActive(true);
				S1.gameObject.SetActive(false);
				time = true;
			}
		}
	}
}
