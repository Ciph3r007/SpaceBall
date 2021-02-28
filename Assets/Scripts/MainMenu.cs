using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

	public TextMeshProUGUI best;
	public TextMeshProUGUI best2;
	public TextMeshProUGUI best3;

	void start(){
		if (!PlayerPrefs.HasKey ("HighScore"))
			PlayerPrefs.SetInt ("HighScore", 0);
		if (!PlayerPrefs.HasKey ("HighScore2"))
			PlayerPrefs.SetInt ("HighScore2", 0);
		if (!PlayerPrefs.HasKey ("HighScore3"))
			PlayerPrefs.SetInt ("HighScore3", 0);
		if (!PlayerPrefs.HasKey ("Help"))
			PlayerPrefs.SetInt ("Help", 1);
	}

	public void PlayGame()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void LeaderBoard()
	{
		best.text = PlayerPrefs.GetInt ("HighScore").ToString ();
		best2.text = PlayerPrefs.GetInt ("HighScore2").ToString ();
		best3.text = PlayerPrefs.GetInt ("HighScore3").ToString ();
	}

	public void LeaderBoard_Reset()
	{
		PlayerPrefs.SetInt ("HighScore", 0);
		PlayerPrefs.SetInt ("HighScore2", 0);
		PlayerPrefs.SetInt ("HighScore3", 0);
		LeaderBoard();
	}

	public void ExitGame()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
}
