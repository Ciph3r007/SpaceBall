using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

	AudioSource aud;

	void Start(){

		aud=gameObject.GetComponent<AudioSource>();
	}

	public void PlayClick(){
	
		if (PlayerPrefs.GetInt ("Sound") == 1)
			aud.Play ();
	}
}
