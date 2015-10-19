using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Win : MonoBehaviour {

	public Text HST;
	public Text ST;
	public GameObject winO;
	public NewPlayer NP;
	public static bool finish;
	public static Dictionary<int, Vector3> savedRecordPos = new Dictionary<int, Vector3>();
	public static Dictionary<int, Quaternion> savedRecordRot = new Dictionary<int, Quaternion>();


	// Use this for initialization
	void Start () {
		finish = false;
		winO.SetActive(false);
	}
	
	public void Finish() {
		recorder.start = false;
		Time.timeScale = 0;
		finish = true;
		NewPlayerController.Lock = false;
		EscMenu.menu = true;
		winO.SetActive(true);
		if (Timer.timer < Timer.highTimer[Lvl.lvlName]) {
			savedRecordPos = recorder.recordpos;
			savedRecordRot = recorder.recordrot;
			PlayerPrefs.SetFloat("timer." + Lvl.lvlName, Timer.timer);
			print(PlayerPrefs.GetFloat("timer." + Lvl.lvlName));

			ST.text = "New high score: " + Timer.timer.ToString("#0.00");
			float difference = Timer.highTimer[Lvl.lvlName] - Timer.timer;
			HST.text = "Old high score: " + Timer.highTimer[Lvl.lvlName].ToString("#0.00") + ". You beat your old time by: " +  difference.ToString("#0.00");
			Timer.highTimer[Lvl.lvlName] = Timer.timer;
			PlayerPrefs.Save();
			//print(Timer.highTimer[Lvl.lvlName]);

		}
		else {
			ST.text = "Score: " + Timer.timer.ToString("#0.00");
			HST.text = "High score: " + Timer.highTimer[Lvl.lvlName].ToString("#0.00");
		}


	}

	public void KP () {
		finish = false;
		NewPlayerController.Lock = true;
		EscMenu.menu = false;
		winO.SetActive(false);
		NP.RES();
	}
	public void MM () {
		
		EscMenu.menu = false;
		winO.SetActive(false);
		Application.LoadLevel("TitleScreen");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
