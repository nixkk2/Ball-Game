using UnityEngine;
using System.Collections;

public class DieTS : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {

			if (gameObject.name == "DieT") {
				other.transform.position = new Vector3 (0, 1.6F, 0);

			}
		}
	}
}
