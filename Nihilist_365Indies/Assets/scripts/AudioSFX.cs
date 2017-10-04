using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFX : MonoBehaviour {

	public AudioClip[] audios;

	public void playDeath(){
		GetComponent<AudioSource> ().clip = audios [0];
		GetComponent<AudioSource> ().Play ();
	}


	public void playButton(){

		GetComponent<AudioSource> ().clip = audios [1];

		GetComponent<AudioSource> ().Play ();

	}

}
