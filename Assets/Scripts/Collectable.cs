using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{	
		if (col.gameObject.tag == "Ball") {
			
			Destroy (gameObject);
		}
	}



}
