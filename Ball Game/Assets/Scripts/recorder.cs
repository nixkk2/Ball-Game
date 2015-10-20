using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class recorder : MonoBehaviour {

	public float timer;
	public static Dictionary<int, Vector3> recordpos = new Dictionary<int, Vector3>();
	public static Dictionary<int, Quaternion> recordrot = new Dictionary<int, Quaternion>();
	public static int recTime;
	public static int playTime;
	public static bool record = true;
	public static bool play = false;
	public GameObject cube;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= 0.0083333333333F && play) {
			playTime++;
			print(recordpos[playTime]);
			cube.transform.position = Win.savedRecordPos[playTime];
			cube.transform.rotation = Win.savedRecordRot[playTime];
		}

		if (timer >= 0.0083333333333F && record) {
			timer = 0;
			recTime++;
			//recordpos.Add(recTime, transform.position);
			recordpos[recTime] = transform.position;
            //recordrot.Add(recTime, transform.rotation);
			recordrot[recTime] = transform.rotation;
        }
		

		
		if(Input.GetKeyDown("space")) {
			play = true;
		}
	}
}
