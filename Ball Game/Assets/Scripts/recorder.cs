using UnityEngine;
using System.Collections;

public class recorder : MonoBehaviour {

	public float timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	}
}
