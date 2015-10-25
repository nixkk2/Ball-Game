using UnityEngine;
using System.Collections;

public class Lvl : MonoBehaviour {

	public NewPlayer NP;
	public NewPlayerController NPC;
	public GameObject lvl;
	public GameObject[] Cubes;
	//public GameObject[] lvls;
	public Material pick;
	public string loadLvlName;
	public static string lvlName;
	public static bool timera;

	// Use this for initialization
	void Start () {
		print(LS.lvlname);
		if(LS.lvlname != "" && LS.lvlname != null) {
			loadLvlName = LS.lvlname;
		}
		
        if (loadLvlName == "" || loadLvlName == null) {
			//loadLvlName = "lvl";
		}
		print(Test.lvls.Length);
		for (int i = 0; i < Test.lvls.Length; i++) {
			if(Test.lvls[i].name == loadLvlName) {
				lvl = Instantiate(Test.lvls[i], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
				NPC.BoostT = NPC.MaxBoostT;
				Load();

			}
		}
		
	}
	
	void Load () {
		lvl.transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);
		lvl.transform.Rotate(0, 180, 0);
		for (int i = 0; i < lvl.transform.childCount; i++) {
			//if(lvl.transform.GetChild(i).name.Contains("Cube_")) {
			lvl.transform.GetChild(i).gameObject.AddComponent<MeshCollider>();
			//}
			if (lvl.transform.GetChild(i).name.Contains("-name")) {
				lvl.transform.GetChild(i).GetComponent<MeshCollider>().enabled = false;
				lvl.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
				string[] arr = lvl.transform.GetChild(i).name.Split(char.Parse("_"));
				lvlName = arr[1];
			}

			if (lvl.transform.GetChild(i).name.Contains("-End")) {
				lvl.transform.GetChild(i).GetComponent<MeshCollider>().enabled = false;
				lvl.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
				BoxCollider bc = lvl.transform.GetChild(i).gameObject.AddComponent<BoxCollider>() as BoxCollider;
				bc.isTrigger = true;
				lvl.transform.GetChild(i).tag = "Finish";
				lvl.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
			}
			else if (lvl.transform.GetChild(i).name.Contains("-RotCube")) {
				lvl.transform.GetChild(i).GetComponent<MeshCollider>().enabled = false;
				lvl.transform.GetChild(i).gameObject.AddComponent<Rot>();
				lvl.transform.GetChild(i).gameObject.GetComponent<Renderer>().material = pick;
			}
			else if (lvl.transform.GetChild(i).name.Contains("-Boost")) {
				//lvl.transform.GetChild(i).GetComponent<MeshCollider>().enabled = false;
				MeshCollider mc = lvl.transform.GetChild(i).gameObject.AddComponent<MeshCollider>() as MeshCollider;
				mc.convex = true;
				mc.isTrigger = true;
				lvl.transform.GetChild(i).tag = "Boost";
			}
			else if (lvl.transform.GetChild(i).name.Contains("-Spawn")) {
				lvl.transform.GetChild(i).GetComponent<MeshCollider>().enabled = false;
				lvl.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;

			}
			if (lvl.transform.GetChild(i).name.Contains("-noDraw")) {
				lvl.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
			}
			if (lvl.transform.GetChild(i).name.Contains("-noCollide")) {
				lvl.transform.GetChild(i).GetComponent<MeshCollider>().enabled = false;
			}
			if (lvl.transform.GetChild(i).name.Contains("-noShadow")) {
				lvl.transform.GetChild(i).GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
			}
			//Cubes.SetValue(lvl.transform.GetChild(i).gameObject, i);

			//Cubes[i] = lvl.transform.GetChild(i).gameObject;
			NP.RES();
		}
		//NewPlayer.
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Load")) {
			Load();
			//print("a");
		}
	}
}
