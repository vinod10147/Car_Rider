using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	private GameController gameController;
	void Start(){
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Opponent") {
			gameController.addScore (1);
		}
		Debug.Log (other.gameObject);
		Destroy (other.gameObject);
	}
}
