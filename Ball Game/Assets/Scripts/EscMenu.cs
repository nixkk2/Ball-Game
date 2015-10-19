using UnityEngine;
using System.Collections;

public class EscMenu : MonoBehaviour {

	public GameObject PauseMenu;
	public GameObject OptionsMenu;
	public static bool menu = false;
	public static bool options = false;

	// Use this for initialization
	void Start () {
		OptionsMenu = GameObject.Find("Options");
		OptionsMenu.SetActive(false);
		PauseMenu = GameObject.Find("PauseMenu") as GameObject;
		PauseMenu.SetActive(false);
		Time.timeScale = 1;
		menu = false;
		NewPlayerController.Lock = true;
	}

	public void butesc() {
		esc(false, false);
	}

	public void esc(bool op, bool op2) {
		if (!Win.finish) {
			options = false;
			OptionsMenu.SetActive(false);
			if (op) {
				menu = !menu;
			}
			else
				menu = op2;
			if (menu == false) {
				Time.timeScale = 1;
				PauseMenu.SetActive(false);
				NewPlayerController.Lock = true;

			}
			else {
				NewPlayerController.Lock = false;
				Time.timeScale = 0;
				PauseMenu.SetActive(true);
				//PauseMenu.set
			}
		}
	}

	void OnApplicationFocus(bool focusStatus) {
		if(focusStatus == false) {
			esc(false, true);
		}
	}

	public void optionsBu() {
		options = true;
		OptionsMenu.SetActive(true);
		PauseMenu.SetActive(false);
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Esc") && !options) {
			esc(true, false);
		}

	}
}
