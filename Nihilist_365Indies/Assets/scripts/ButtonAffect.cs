using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAffect : MonoBehaviour {

	public GameObject door;
	public bool active = false;

	private Camera cam;
	private int _count = 0;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		
	}
	
	// Update is called once per frame
	void Update () {
		active = !isEmpty ();
			
		door.GetComponent<DoorMovement> ().Opened = active;

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Ghost") {
			if(_count == 0)
				cam.GetComponent<AudioSFX> ().playButton ();
			++_count;
		}
	}


	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Ghost") {
			--_count;
		}
	}

	bool isEmpty(){
		return _count == 0;
	}
}
