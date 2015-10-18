using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class options : MonoBehaviour {

    public NewCameraController CC;
    public NewPlayerController PC;
    public NewPlayer Ply;
    public EscMenu EM;
    public Toggle boost;
    public Slider sensitivityS;
    public Text sensitivityTxt;

    public static bool advancedB = false;
    public GameObject advanced;
    public GameObject normal;

    public static bool Boost = true;


    // Use this for initialization
    void Start () {
        NewCameraController.sensitivity = PlayerPrefs.GetFloat("options.sensitivity", 120);
        sensitivityS.value = PlayerPrefs.GetFloat("options.sensitivity", 120);
        if (PlayerPrefs.GetInt("options.advanced", 0) == 0) {
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
        NewCameraController.sensitivity = sensitivityS.value;
        PlayerPrefs.SetFloat("options.sensitivity", sensitivityS.value);
        if (advancedB) {
            PlayerPrefs.SetInt("options.advanced", 1);
        }
        else
            PlayerPrefs.SetInt("options.advanced", 0);

        //NewPlayerController.speed = float.Parse((speed.text));
    } 

    public void ok() {
        apply();
        EM.esc(false);
    }

    public void sensitivityC () {
        sensitivityTxt.text = sensitivityS.value.ToString("#0.00");
    }

    // Update is called once per frame
    void Update () {
        
    }
}
