using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateInstance : MonoBehaviour {

	// Use this for initialization
	public Transform currentRoad;
	Rigidbody rb;
	bool flag;
	void Start () {
		rb = GetComponent<Rigidbody> ();
		flag = true;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (rb.transform.position.z + " " + currentRoad.position.z);
		if (flag && rb.transform.position.z <= currentRoad.position.z) {
			GameObject gameObject = GameObject.FindGameObjectWithTag ("GameController");
			GameController gameController=gameObject.GetComponent<GameController>();
			gameController.generateRoad ();
			flag = false;
		}
	}
}
