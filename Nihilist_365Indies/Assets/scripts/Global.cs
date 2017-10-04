using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

	public static int lastCheckpoint = 0;

	public static List<GameObject> ghostList = new List<GameObject>();

	public static bool menu = true;

	public static bool gameplay = false;
	public static bool ending = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
