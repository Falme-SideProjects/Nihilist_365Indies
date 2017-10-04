using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour {

	public Transform posOpen, posEnd;
	public bool Opened = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Opened) {
			transform.position = Vector3.Lerp (transform.position, new Vector3(posOpen.position.x, posOpen.position.y, transform.position.z), 0.3f);
		} else {
			transform.position = Vector3.Lerp (transform.position, new Vector3(posEnd.position.x, posEnd.position.y, transform.position.z), 0.3f);
		}
	}

}
