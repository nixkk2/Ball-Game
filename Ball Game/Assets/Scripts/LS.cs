using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LS : MonoBehaviour {

	public GameObject main;
	public GameObject LevelSelect;
	public static string lvlname;
	public GameObject Butt;
	public GameObject con;
	public Vector3 buttPos;

	// Use this for initialization
	void Start() {
		buttPos = new Vector3(217.1F, 308, 1);
		for (int i = 0; i < Test.lvls.Length; i++) {
			GameObject GO = Instantiate(Butt, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			//GO.transform.parent = con.transform;
			GO.transform.SetParent(con.transform);
            GO.transform.name = Test.lvls[i].name;
			GO.transform.GetChild(0).GetComponent<Text>().text = Test.lvls[i].name;

			GO.GetComponent<RectTransform>().position = buttPos;
			buttPos = new Vector3(buttPos.x, buttPos.y - 35, buttPos.z);
			string captured = Test.lvls[i].name;
			GO.GetComponent<Button>().onClick.AddListener(() => lvl(captured));
		}
	}

	public void MTL (bool ba) {
		if (ba) {
			main.gameObject.SetActive(false);
			LevelSelect.gameObject.SetActive(true);
		}
		else {
			main.gameObject.SetActive(true);
			LevelSelect.gameObject.SetActive(false);
		}

	}
	public void lvl (string str) {
		lvlname = str;
		Application.LoadLevel("lvl");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
