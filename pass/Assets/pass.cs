using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pass : MonoBehaviour {

	public InputField IF;
	public Text IPT;

	// Use this for initialization
	void Start () {
	
	}


	public static int IntParseFast(string value) {
		int result = 0;
		for (int i = 0; i < value.Length; i++) {
			char letter = value[i];
			//result = 10 * result + (letter - 48);
			result = 10 * result + (letter - 48 - 48);
		}
		return result;
	}

	public void passF () {
		print(IntParseFast(IPT.text).ToString());
		IF.interactable = false;
		var input = IPT.text;
		for (int i = 1; i <= input.Length; i++) {

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
