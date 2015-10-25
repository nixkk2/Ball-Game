using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewPlayerController : MonoBehaviour {

	public float Bspeed;
	public float Aspeed = 120;
	public static float Nspeed;
	
	public float MaxBoostT = 5;
	public GameObject PlayerCamera;
	public NewCameraController PCS;
	public Scrollbar bar;
	public Scrollbar bar2;
	public Vector3 BV;
	public bool BB = false;
	public static bool Lock;
	public Vector3 movement;

	public Win win;

	private Quaternion notup;
	private float moveHorizontal;
	private float moveVertical;
	public float BoostT;
	private Rigidbody rb;

	private static float speed;



	// Use this for initialization
	void Start () {

		Nspeed = Aspeed;
		Lock = true;
		
		speed = Nspeed;
		rb = GetComponent<Rigidbody>();

	}

	


	public void Quit () {
		Application.LoadLevel("TitleScreen");
		//Application.Quit();
	}


	void OnTriggerStay(Collider col) {
		if (col.tag == "Boost") {
			string[] arr = col.name.Split(char.Parse("_"));
			rb.AddForce(new Vector3(float.Parse(arr[1]), float.Parse(arr[2]), float.Parse(arr[3])));
		}
		
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag.Equals("Finish")) {
			print("Finish");
			win.Finish();

			
		}
		
	}

	ColorBlock red;
	ColorBlock white;
	void Update () {
		


		//float YR = PCS.YR
		if (Input.GetButtonDown("Lock") && !EscMenu.menu) {

			if (Lock)
				Lock = false;
			else
				Lock = true;
		}


		if (Lock) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		if (options.Boost) {

			if(Input.GetButton("Boost") && !EscMenu.menu) {
				
				if (BB) {
					Timer.timerB = true;
					MaxBoostT = 0;
					BB = false;
					//BV = new Vector3(0, 0, Bspeed);
					rb.AddForce(Quaternion.Euler(new Vector3(0, PCS.XR, 0)) * new Vector3(0, 0, Bspeed));
				}
				else {
					//BV = new Vector3(0, 0, 0);
				}
				BB = false;
			}
			if (MaxBoostT >= BoostT) {
				//boostP.GetComponent<RawImage>().color = new Color(1, 0, 0, 1);
				//print(MaxBoostT >= BoostT);
				red = bar.colors;
				red.disabledColor = Color.red;
				bar2.colors = red;
				bar.colors = red;
				BB = true;
			}
			if (MaxBoostT <= BoostT) {
				
				white = bar2.colors;
				white.disabledColor = Color.white;
				bar2.colors = white;
				bar.colors = white;

				MaxBoostT += Time.deltaTime;
				//bar.size = 1 / (BoostT / MaxBoostT);
				if(options.advancedB) {
					bar.size = (MaxBoostT / BoostT) / 1;
					bar2.size = (MaxBoostT / BoostT) / 1;
					//boostP.transform.position = new Vector3(338.8F + (166.4F / (BoostT / MaxBoostT)), boostP.transform.position.y, boostP.transform.position.z);

					//boostP.transform.position = new Vector3(boostP2.transform.position.x / 1.8F + (166.4F / (BoostT / MaxBoostT)), boostP.transform.position.y, boostP.transform.position.z);
					//boostP.transform.localScale = new Vector3(((MaxBoostT / BoostT) / 1) * 1.0F, boostP.transform.localScale.y, boostP.transform.localScale.y);
					//boostP.transform.position = new Vector3(60 + (), boostP.transform.position.y, boostP.transform.position.z);
				}
				else
					bar.size = (MaxBoostT / BoostT) / 1;
			}


		}
		/*
		notup = PlayerCamera.transform.rotation;
		notup = Quaternion.identity;

		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		move = move.normalized * Time.deltaTime * speed;
		GetComponent<Rigidbody>().AddRelativeForce(move);
		*/
	}

	void FixedUpdate () {

		
		notup = PlayerCamera.transform.rotation;
		notup = Quaternion.identity;

		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");
		if(moveHorizontal != 0 && moveVertical != 0) {
			//moveHorizontal *= .7072F;
			//moveVertical *= .7072F;
		}

		if(moveHorizontal != 0 || moveVertical != 0) {
			Timer.timerB = true;
		}
		
		movement = new Vector3 (moveHorizontal, 0, moveVertical);
		movement = Vector3.Normalize(movement);
        notup = Quaternion.Euler(new Vector3(0, PCS.XR, 0));
		//notup.y = PCS.YR;
		
        movement = notup * movement;

		//rb.AddForce (movement * speed);
		rb.AddForce(movement * speed * Time.deltaTime);
		
	}
}