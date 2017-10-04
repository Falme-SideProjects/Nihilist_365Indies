using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

	public GameObject ghost;
	public Vector3 origPos;

	private Camera cam;

	public GameObject toFollowPlayer, toFollowMouse;


	// Use this for initialization
	void Start () {
		origPos = transform.position;

		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Die(){

		cam.GetComponent<AudioSFX> ().playDeath ();

		GameObject go = (GameObject)Instantiate (ghost, transform.position, Quaternion.identity);
		go.GetComponent<GhostFollow> ().player = toFollowPlayer.transform;
		go.GetComponent<GhostFollow> ().mouseObj = toFollowMouse.transform;

		Global.ghostList.Add (go);
		if (Global.ghostList.Count > 3) {
			Destroy (Global.ghostList [0].gameObject);
			Global.ghostList.RemoveAt (0);
		}
		transform.position = origPos;
	}

	public void setCheckpoint (Transform tr){
		origPos = new Vector3 (tr.position.x, transform.position.y, transform.position.z);
	}


	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Spike") {
			Die ();
		}

		if (col.tag == "Checkpoint") {
			if(col.GetComponent<Checkpoint>().isNew())
				setCheckpoint (col.transform);
		}
	}
}
