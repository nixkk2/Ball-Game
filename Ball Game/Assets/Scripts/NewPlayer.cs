using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewPlayer : MonoBehaviour {

	public Text SpeedT;
	public Text HiSpeedT;
	private Rigidbody rb;
	public Transform Spawn;
	public NewPlayerController PC;
	public float timer;
	public bool timerB = true;
	public Win win;
	public float hiSpeed;
	public GameObject cam;

	// Use this for initialization
	void Start () {
		HiSpeedT.text = "";
		hiSpeed = 0;
		
		
		
		//transform.position = Spawn.position;

	}

	public void RES () {
		Lvl.timera = true;
		Spawn = GameObject.Find("-Spawn").transform;
		HiSpeedT.text = "";
		hiSpeed = 0;
		/*
		recorder.recordpos.Clear();
		recorder.recordrot.Clear();
		print(Win.savedRecordPos.Count);

		//if (Win.savedRecordPos.Count > 0) {
			recorder.playTime = 0;
			recorder.play = true;
		//}
		recorder.recTime = 0;
		recorder.record = true;
		*/
		Time.timeScale = 1;
		Timer.timerB = false;
		Timer.timer = 0;
		//NewCameraController.YR = 
		transform.position = Spawn.position;
		transform.rotation = Quaternion.Euler(0, 0, 0);
		rb = gameObject.GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		rb.velocity = new Vector3 (0, 0, 0);
		rb.freezeRotation = false;
		PC.MaxBoostT = PC.BoostT;
	}

	void Update () {
		var speeda = (Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y) + Mathf.Abs(rb.velocity.z));
		if (speeda > hiSpeed && Timer.timerB) {
			hiSpeed = speeda;
			HiSpeedT.text = "High Speed: " + hiSpeed.ToString("#0.00");
		}
		SpeedT.text = "Speed: " + speeda.ToString("#0.00");

		if (timerB) {
			timer += Time.deltaTime;
		}
		if (timer >= 0.05F && timerB) {
            transform.position = Spawn.position;
			timerB = false;
		}
		if (Input.GetButtonDown ("RS")) {
			if (!EscMenu.menu) {
				RES();
			}
			else if (Win.finish) {
				win.KP();
			}
			
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.y < -10) {
			RES ();
		}
	}
}
