using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRestore : MonoBehaviour {
	void Start () {
		PlayerPrefs.SetInt ("Sound", 1);
	}
}
