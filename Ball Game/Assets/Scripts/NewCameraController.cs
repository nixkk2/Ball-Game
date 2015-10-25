using UnityEngine;
using System.Collections;


public class NewCameraController : MonoBehaviour {



	GameObject player;
	public Quaternion Erotation;
	Quaternion targetLook;
	Vector3 targetMove;
	public float rayHitMoveInFront = 0.2f;
	Vector3 targetMoveUse;
	public float smoothLook = 0.5f;
	public float smoothMove = 0.5f;
	Vector3 smoothMoveV;
	public float distFormPlayer = 5;
	public float heightFromPlayer = 3;
	public static float YR;
	public float XR;
    public float ZR;
    public static float sensitivity = 120;

	Renderer rend;
	public Color playerColor = Color.white;

	void Start () {

		player = GameObject.FindWithTag("Player");
		//rend = GetComponent<Renderer>();
		rend = player.GetComponent<Renderer>();
	}

	void OnGUI() {
		//GUI.Label(new Rect(10, 10, 100, 20), "" + Vector3.Distance (player.transform.position, transform.position));
	}
	

	void Update () {


		if (NewPlayerController.Lock && !EscMenu.menu) {
			XR += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
			YR -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
			distFormPlayer += -Input.GetAxis("Mouse ScrollWheel") * 1000 * Time.deltaTime;
			distFormPlayer = Mathf.Clamp(distFormPlayer, 2, 20);
		}
		YR = Mathf.Clamp(YR, -70, 70);
		Erotation = Quaternion.Euler(YR, XR, ZR);





		targetMove = player.transform.position + (Erotation * new Vector3(0, 0, -distFormPlayer));

		RaycastHit hit;
		if (Physics.Raycast(player.transform.position, targetMove - player.transform.position, out hit, Vector3.Distance(player.transform.position, targetMove)))
			targetMoveUse = Vector3.Lerp(hit.point, player.transform.position, rayHitMoveInFront);
		else
			targetMoveUse = targetMove;






		//transform.position = Vector3.Lerp(transform.position, targetMoveUse, smoothMove * Time.deltaTime);
		//transform.position = Vector3.SmoothDamp(transform.position, targetMoveUse, ref smoothMoveV, smoothMove * Time.deltaTime);
		transform.position = targetMoveUse;

		//targetLook = Quaternion.LookRotation(player.transform.position - transform.position);
		//transform.rotation = Quaternion.Slerp(transform.rotation, targetLook, smoothLook * Time.deltaTime);
		transform.LookAt(player.transform.position);
		//transform.rotation = targetLook;

		if (Vector3.Distance (player.transform.position, transform.position) < 3) {
			playerColor.a = Vector3.Distance (player.transform.position, transform.position) / 12;
			rend.material.color = playerColor;
		}
		else{
			playerColor.a = 1;
			rend.material.color = playerColor;
		}
	}	
}
