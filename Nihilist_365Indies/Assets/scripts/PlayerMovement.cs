using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float velocityMovement;

	private Animator animator;

	public GameObject dialogue;

	public GameObject npCamera;
	public bool lastMoment = false;

	//public float velocityJump;

	//public bool canJump = true;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		rb2d.velocity = Vector3.right * 0;

		if (Global.gameplay) {
			
			movementation ();
		}

		if (lastMoment) {
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, new Vector3(npCamera.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z), 0.051f);
		}

		/*if (canJump && Input.GetKeyDown (KeyCode.Space)) {
			rb2d.AddForce (new Vector2(0, velocityJump));
			canJump = false;
		}*/
	}

	void movementation (){

		float move = Input.GetAxis ("Horizontal");

		rb2d.velocity = (Vector3.right * move) * velocityMovement * Time.deltaTime;

		if (move > 0) {
			animator.SetBool("Walking",true);
			GetComponent<SpriteRenderer> ().flipX = false;
		} else if (move < 0) {

			animator.SetBool("Walking",true);
			GetComponent<SpriteRenderer> ().flipX = true;
		} else {

			animator.SetBool("Walking",false);
		}
	}


	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "EndGame") {
			animator.SetBool("Walking",false);
			animator.SetBool("Die",true);
			dialogue.SetActive (true);
			Global.gameplay = false;
			Global.ending = true;
			lastMoment = true;
		}
			
	}

	/*void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Floor") {
			canJump = true;
		}
	}*/
}
