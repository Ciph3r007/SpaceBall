using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScript : MonoBehaviour {
	
	public void SoundOn(){
		PlayerPrefs.SetInt ("Sound", 1);
	}
	public void SoundOff(){
		PlayerPrefs.SetInt ("Sound", 0);
	}

	public void DiffEasy() {
		PlayerPrefs.SetInt ("Difficulty", 0);
	}
	public void DiffMed() {
		PlayerPrefs.SetInt ("Difficulty", 1);
	}
	public void DiffHard() {
		PlayerPrefs.SetInt ("Difficulty", 2);
	}

	public void HelpOn(){
		PlayerPrefs.SetInt ("Help", 1);
	}
	public void HelpOff(){
		PlayerPrefs.SetInt ("Help", 0);
	}
}
