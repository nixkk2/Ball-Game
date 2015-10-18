using UnityEngine;
using System.Collections;

public class Rot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(15 * Time.deltaTime, 15 * Time.deltaTime, 15 * Time.deltaTime);
	}
}
