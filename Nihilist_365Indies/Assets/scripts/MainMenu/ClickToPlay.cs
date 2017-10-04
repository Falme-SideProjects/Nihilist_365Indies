using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickToPlay : MonoBehaviour {

	private bool CantClick = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (Global.menu) {

				//GetComponent<Image> ().color.a = Mathf.Lerp (1f, 0f, 0.3f);
				Global.menu = false;
				Global.gameplay = true;
				gameObject.SetActive (false);
			} else if (Global.ending) {
				Global.menu = true;
				Global.gameplay = false;
				Global.ending = false;
				SceneManager.LoadScene (0);

			}
		}
	}


}
