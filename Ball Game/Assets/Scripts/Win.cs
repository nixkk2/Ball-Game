using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Win : MonoBehaviour {

    public Text HST;
    public Text ST;
    public GameObject winO;
    public NewPlayer NP;
    public static bool finish;

    // Use this for initialization
    void Start () {
        finish = false;
        winO.SetActive(false);
	}
	
    public void Finish() {
        Time.timeScale = 0;
        finish = true;
        NewPlayerController.Lock = false;
        EscMenu.menu = true;
        winO.SetActive(true);
        if (Timer.timer < Timer.highTimer[Lvl.lvlName]) {
            ST.text = "New high score: " + Timer.timer.ToString("#0.00");
            float difference = Timer.highTimer[Lvl.lvlName] - Timer.timer;
            HST.text = "Old high score: " + Timer.highTimer[Lvl.lvlName].ToString("#0.00") + ". You beat your old time by: " +  difference.ToString("#0.00");
            Timer.highTimer[Lvl.lvlName] = Timer.timer;
            PlayerPrefs.SetFloat("timer." + Lvl.lvlName, Timer.highTimer[Lvl.lvlName]);
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
