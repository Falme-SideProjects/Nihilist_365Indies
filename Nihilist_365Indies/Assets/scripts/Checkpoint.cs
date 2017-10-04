using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public int flag;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool isNew(){
		if (Global.lastCheckpoint < flag) {
			Global.lastCheckpoint = flag;
			return true;
		}

		return false;
	}
}
