using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTrigger : MonoBehaviour {

	private Camera camera;

	// Use this for initialization
	void Start () {
		this.camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			this.camera.transform.position = new Vector3(transform.position.x, transform.position.y, this.camera.transform.position.z);
		}
	}

}
