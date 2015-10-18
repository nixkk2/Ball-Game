using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour {

    public static float timer;
    public static bool timerB = false;
    public static Dictionary<string, float> highTimer = new Dictionary<string, float>();
    //public static float highTimer = 0;
    public Text time;
    public Text highTime;
    public bool timer2B;
    public float timer2;

    // Use this for initialization
    void Start () {
        timer = 0;
        print(Lvl.lvlName);
        print(highTimer[Lvl.lvlName].ToString("#0.00"));

        highTimer.Add(Lvl.lvlName, 999);
        if (PlayerPrefs.GetFloat("timer." + Lvl.lvlName, 999) <= 0 || highTimer[Lvl.lvlName] <= 0) {
            //highTimer.Add(Lvl.lvlName, 999);
            PlayerPrefs.SetFloat("timer." + Lvl.lvlName, 999);
            highTimer[Lvl.lvlName] = 999;
            //highTimer[Lvl.lvlName] = 999;
        }
        else {
            highTimer[Lvl.lvlName] = PlayerPrefs.GetFloat("timer." + Lvl.lvlName);
            //highTimer.Add(Lvl.lvlName, PlayerPrefs.GetFloat(Lvl.lvlName));
        }
        //highTimer[Lvl.lvlName] = PlayerPrefs.GetFloat("timer." + Lvl.lvlName);
        //highTimer = PlayerPrefs.GetFloat(Lvl.lvlName);
        highTimer[Lvl.lvlName] = 999;
        print(highTimer[Lvl.lvlName].ToString("#0.00"));
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetButton("RS")) {
            timer2B = true;
            if(timer2 >= 3) {
                
                PlayerPrefs.SetFloat("timer." + Lvl.lvlName, 999);
                //highTimer.Add(Lvl.lvlName, 999);
                highTimer[Lvl.lvlName] = 999;
            }
            //if (timer2 >= 5) {

                //PlayerPrefs.DeleteAll();
            //}
        }
        else {
            timer2B = false;
            timer2 = 0;
        }

        if(timer2B) {
            timer2 += Time.deltaTime;
        }
        if(timerB)
            timer += Time.deltaTime;

        time.text = "Timer: " + timer.ToString("#0.00");
        //highTime.text = "High Score: " + highTimer[Lvl.lvlName].ToString("#0.00");
    }
}
