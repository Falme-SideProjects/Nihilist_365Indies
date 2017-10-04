using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowableObject : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		//Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnMouseDown(){
		Debug.Log ("obj");
		if (InputBehaviour.ghostCursor != null) {
			GhostFollow gf = InputBehaviour.ghostCursor.GetComponent<GhostFollow> ();
			gf.whoFollow = GhostFollow.WhoFollow.sceneObject;
			gf.selectedObject = transform;
			InputBehaviour.ghostCursor = null;
			//InputBehaviour.ghostCursor = gameObject;
		}
	}
}
