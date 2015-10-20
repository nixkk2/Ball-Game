using UnityEngine;
using System.Collections;

public class LS : MonoBehaviour {

	public GameObject main;
	public GameObject LevelSelect;

	// Use this for initialization
	void Start () {
	
	}
	
	public void MTL (bool ba) {
		if (ba) {
			main.gameObject.SetActive(false);
			LevelSelect.gameObject.SetActive(true);
		}
		else {
			main.gameObject.SetActive(true);
			LevelSelect.gameObject.SetActive(false);
		}

	}
	public void lvl () {

		Application.LoadLevel("lvl");
	}
	public void lvl2() {
		Application.LoadLevel("lvl2");
	}
	public void tutorial() {
		Application.LoadLevel("tutorial");
	}

	public void lvl3() {
		Application.LoadLevel("lvl3");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
