using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class options : MonoBehaviour {

    public NewCameraController CC;
    public NewPlayerController PC;
    public NewPlayer Ply;
    public EscMenu EM;
    public Toggle boost;

    public static bool advancedB = false;
    public GameObject advanced;
    public GameObject normal;

    public static bool Boost = true;


    // Use this for initialization
    void Start () {
        if(PlayerPrefs.GetInt("advanced", 0) == 0) {
            advancedB = false;
        }
        else
            advancedB = true;
        //advancedB = 
        boost.isOn = advancedB;
        advanced.SetActive(advancedB);
        normal.SetActive(!advancedB);
        //boost = GameObject.Find("BoostToggle").GetComponent<Toggle>();
        //speed.text = NewPlayerController.Nspeed.ToString;

    }
	
    public void apply() {

        advancedB = boost.isOn;
        advanced.SetActive(advancedB);
        normal.SetActive(!advancedB);

        if(advancedB) {
            PlayerPrefs.SetInt("advanced", 1);
        }
        else
            PlayerPrefs.SetInt("advanced", 0);

        //NewPlayerController.speed = float.Parse((speed.text));
    } 

    public void ok() {
        apply();
        EM.esc(false);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
