using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoLoader : MonoBehaviour {

	void Start () {
		StartCoroutine ("Countdown");
	}

	private IEnumerator Countdown() {
		yield return new WaitForSeconds (3f);

		float fadeTime = GameObject.Find ("Fader").GetComponent<Fade> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
	}
}
