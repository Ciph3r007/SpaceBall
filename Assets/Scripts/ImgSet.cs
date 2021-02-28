using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgSet : MonoBehaviour {

	public GameObject easy;
	public GameObject medium;
	public GameObject hard;
	public GameObject on;
	public GameObject off;
	public GameObject on2;
	public GameObject off2;
	private int x;
	private int y;
	private int z;

	void Update () {
		x = PlayerPrefs.GetInt ("Difficulty");
		y = PlayerPrefs.GetInt ("Sound");
		z = PlayerPrefs.GetInt ("Help");

		if (x == 0) {
			easy.SetActive (true);
			medium.SetActive (false);
			hard.SetActive (false);
		} else if (x == 1) {
			medium.SetActive (true);
			easy.SetActive (false);
			hard.SetActive (false);
		} else if (x == 2) {
			medium.SetActive (false);
			easy.SetActive (false);
			hard.SetActive (true);
		} else {
		
			medium.SetActive (false);
			easy.SetActive (false);
			hard.SetActive (false);
		}
		if (y == 0) {
			on.SetActive (false);
			off.SetActive (true);
		} else {
			on.SetActive (true);
			off.SetActive (false);
		}
		if (z == 0) {
			on2.SetActive (false);
			off2.SetActive (true);
		} else {
			on2.SetActive (true);
			off2.SetActive (false);
		}
			
	}
}
