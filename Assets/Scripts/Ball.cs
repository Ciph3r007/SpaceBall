using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using TMPro;

public class Ball : MonoBehaviour {

	public GameObject GameOverPanel;
	public GameObject TutorialPanel;
	public TextMeshProUGUI score;
	public TextMeshProUGUI best;
	private float speed;
	public float jumpForce;
	public AudioSource track;
	public AudioSource pop;
	public AudioSource broken;
	public AudioSource end;
	private Rigidbody rb;
	private bool gameOver;
	private int count;
	private int temp;
	private int checker;

	float x, y;

	void Start () {
		
		rb = GetComponent<Rigidbody> ();

		if(PlayerPrefs.GetInt("Sound") == 1)
			track.Play ();
		
		if (PlayerPrefs.GetInt ("Help") == 1) {
			TutorialPanel.SetActive (true);
			PlayerPrefs.SetInt ("Help", 0);
		}else
			TutorialPanel.SetActive (false);
		
		GameOverPanel.SetActive (false);

		count = 0;
		SetScore ();
		gameOver = false;
		checker = 1;
		temp = PlayerPrefs.GetInt ("HighScore");
	}

	void Main()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	void Update(){
	
		if (transform.position.y<-20) {
			if (count > temp) {
				PlayerPrefs.SetInt ("HighScore3", PlayerPrefs.GetInt ("HighScore2"));
				PlayerPrefs.SetInt ("HighScore2", temp);
			} else if (count < PlayerPrefs.GetInt ("HighScore") && count > PlayerPrefs.GetInt ("HighScore2")) {
				temp = PlayerPrefs.GetInt ("HighScore2");
				PlayerPrefs.SetInt ("HighScore2", count);
				PlayerPrefs.SetInt ("HighScore3", temp);
			} else if (count < PlayerPrefs.GetInt ("HighScore2") && count > PlayerPrefs.GetInt ("HighScore3")) {
				PlayerPrefs.SetInt ("HighScore3", count);
			}

			
			gameOver = true;
			track.Stop() ;
			GameOverPanel.SetActive (true);
			if (PlayerPrefs.GetInt ("Sound") == 1)
				end.Play ();
			gameObject.SetActive (false);

		}
	
	}

	void FixedUpdate () {
		
		if (SystemInfo.deviceType == DeviceType.Desktop) {
			
			x = Input.GetAxis ("Horizontal");
			y = Input.GetAxis ("Vertical");
			speed = 7;

			Vector3 movements = new Vector3 (x, 0.0f, y);
			rb.AddForce (movements * speed);

			if (Input.GetButtonDown ("Jump") && transform.position.y < .5f) {
				rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
			}

		}else{
			speed = 1000;
			Vector3 movements = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y+0.3f);

			rb.AddForce (movements * speed * Time.deltaTime);

			if (Input.GetMouseButtonDown (0) && transform.position.y < .5f) {
				rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{	
		if (col.gameObject.tag == "Collectibles") {
			count+=10;
			if(PlayerPrefs.GetInt("Sound")==1)
			pop.Play ();
			SetScore();
		}
		    count++;
			SetScore ();

	}


	public void restart()
	{
		
		Application.LoadLevel (Application.loadedLevel);
	}

	void SetScore()
	{
		score.text = "Score " + count.ToString ();

		if(count > PlayerPrefs.GetInt("HighScore")){
			PlayerPrefs.SetInt ("HighScore", count);
			if (checker == 1) {
				if(PlayerPrefs.GetInt("Sound")==1)
				broken.Play ();
				checker = 0;
			}

		}

		best.text = "Best " + PlayerPrefs.GetInt("HighScore").ToString ();
	}
}