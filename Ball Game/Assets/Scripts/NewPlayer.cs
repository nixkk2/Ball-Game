using UnityEngine;
using System.Collections;

public class NewPlayer : MonoBehaviour {


	private Rigidbody rb;
	public Transform Spawn;
	public NewPlayerController PC;
	public float timer;
	public bool timerB = true;
	public Win win;

	// Use this for initialization
	void Start () {
		Spawn = GameObject.Find("-Spawn").transform;
		
		rb = gameObject.GetComponent<Rigidbody> ();
		transform.position = Spawn.position;

	}

	public void RES () {
		Time.timeScale = 1;
		Timer.timerB = false;
		Timer.timer = 0;
		PC.MaxBoostT = PC.BoostT;
		//NewCameraController.YR = 
		transform.position = Spawn.position;
		transform.rotation = Quaternion.Euler(0, 0, 0);
		rb.freezeRotation = true;
		rb.velocity = new Vector3 (0, 0, 0);
		rb.freezeRotation = false;
	}

	void Update () {
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
