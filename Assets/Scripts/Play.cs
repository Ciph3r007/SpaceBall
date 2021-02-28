using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour {

	AudioSource aud;

	void Awake(){

		aud = gameObject.GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("Sound") == 1)
			aud.Play ();
	}

	public void PlayMusic(){
		aud.Play ();
	}

	public void StopMusic(){
		aud.Stop ();
	}
}
