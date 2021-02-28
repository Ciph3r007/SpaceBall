using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
	Vector3 lastPos;
	float sizeX;
	float sizeZ;
	private int x = 0;
	private int y;
	public GameObject platform;
	public GameObject diamonds;

	void Start () {
		if (PlayerPrefs.GetInt ("Difficulty") == 0)
			y = 80;
		else if (PlayerPrefs.GetInt ("Difficulty") == 1)
			y = 30;
		else if (PlayerPrefs.GetInt ("Difficulty") == 2)
			y = 20;
		else if (!PlayerPrefs.HasKey ("Difficulty"))
			y = 35;	
		lastPos = platform.transform.position;
		sizeX = platform.transform.localScale.x;
		sizeZ = platform.transform.localScale.z;
		for (int i = 0; i < 10; i++) {
			Spawn ();
		}

		InvokeRepeating ("Spawn", 2f, .1f);
	}

	void Spawn(){
		int rand = Random.Range (0, 6);
		int rand1 = Random.Range (0, y);
		if (rand < 3)
			SpawnX ();
		else
			SpawnZ ();
		if (rand1<=3 && x==1)
			SpawnFake ();

	}

	void SpawnX(){
		x = 1;
		Vector3 pos = lastPos;
			pos.x += sizeX;
		lastPos = pos;
		Instantiate (platform, pos, Quaternion.identity);
		int rand = Random.Range (0, 5);
		if(rand==3)
		Instantiate (diamonds, new Vector3(pos.x,pos.y+.5f,pos.z), diamonds.transform.rotation);
	}
	void SpawnZ(){
		x = 1;
		Vector3 pos = lastPos;
			pos.z += sizeZ;
		lastPos = pos;
		Instantiate (platform, pos, Quaternion.identity);
		int rand = Random.Range (0, 5);
		if(rand==0)
			Instantiate (diamonds, new Vector3(pos.x,pos.y+.5f,pos.z), diamonds.transform.rotation);
	}
	void SpawnFake(){
		Vector3 pos = lastPos;
		pos.x += sizeX;
		lastPos = pos;
		x = 0;
	}
}
