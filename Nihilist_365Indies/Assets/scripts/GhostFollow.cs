using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFollow : MonoBehaviour {

	public enum WhoFollow {
		player,
		mouse,
		sceneObject
	}

	public WhoFollow whoFollow;

	public Transform player, selectedObject, mouseObj;
	private float movementTime;

	// Use this for initialization
	void Start () {
		movementTime = Random.Range (0.01f, 0.1f);
		whoFollow = WhoFollow.player;
	}
	
	// Update is called once per frame
	void Update () {

		if (whoFollow == WhoFollow.player) {
			followPlayer ();
		} else if (whoFollow == WhoFollow.mouse) {
			followMouse ();
		} else if (whoFollow == WhoFollow.sceneObject) {
			followObject ();
		} 

		if (Input.GetMouseButtonDown (1)) {
			if (whoFollow == WhoFollow.mouse) {
				whoFollow = WhoFollow.player;
				InputBehaviour.ghostCursor = null;
			}
		}

	}

	void followPlayer(){

		transform.position = Vector3.Lerp(transform.position, player.position, movementTime);
		verifyFlip (player.position.x);
	}



	void followObject(){

		transform.position = Vector3.Lerp(transform.position, new Vector3(selectedObject.position.x, selectedObject.position.y, -5.1f), movementTime);
		verifyFlip (selectedObject.position.x);
	}

	void followMouse(){


		transform.position = Vector3.Lerp(transform.position, mouseObj.position, movementTime);
		verifyFlip (mouseObj.position.x);

		/*Vector3 p = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0f));

		transform.position = Vector3.Lerp(transform.position, new Vector3(p.x, p.y,  transform.position.z), movementTime);
		verifyFlip (p.x);*/
		
	}

	void OnMouseDown(){
		if (InputBehaviour.ghostCursor == null) {
			whoFollow = WhoFollow.mouse;
			InputBehaviour.ghostCursor = gameObject;
		}

		if (whoFollow == WhoFollow.sceneObject) {
			whoFollow = WhoFollow.player;
		}
	}

	void verifyFlip(float x){
		if (transform.position.x > x) {

			GetComponent<SpriteRenderer> ().flipX = true;
		} else {

			GetComponent<SpriteRenderer> ().flipX = false;
		}
	}
}
