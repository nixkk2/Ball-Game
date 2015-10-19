using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class recorder : MonoBehaviour {

	public float timer;
	public static Dictionary<int, Vector3> recordpos = new Dictionary<int, Vector3>();
	public static Dictionary<int, Quaternion> recordrot = new Dictionary<int, Quaternion>();
	public int i;
	public int i2; 
	public static bool start = false;
	public GameObject cube;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >= 0.025F) {
			timer = 0;
			i++;
			recordpos.Add(i, transform.position);
			recordrot.Add(i, transform.rotation);
		}
		if(timer >= 0.025F && start && i2 < i) {
			timer = 0;
			i2++;
			cube.transform.position = Win.savedRecordPos[i2];
			cube.transform.rotation = Win.savedRecordRot[i2];
		}

		if(Input.GetKeyDown("space")) {
			start = true;
		}
	}
}
