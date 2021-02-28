using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour {

	float time;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("Difficulty") == 0) {
			time = 4f;
			Debug.Log ("asaf");
		} else if (PlayerPrefs.GetInt ("Difficulty") == 1) {
			time = 2f;
			Debug.Log ("asf");
		} else if (PlayerPrefs.GetInt ("Difficulty") == 2) {
			time = 1f;
			Debug.Log ("aaf");
		} else {
			time = 3f;
			Debug.Log ("asa");
		}
	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Ball") {
			Invoke("fallDown", time);
		
		}
	}
	void fallDown(){
		GetComponentInParent<Rigidbody> ().isKinematic = false;
		GetComponentInParent<Rigidbody>().useGravity = true;
		Destroy (transform.parent.gameObject, 2f);
	}
}
