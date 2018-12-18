using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	public int lanes;
	public float moveRate;
	private float laneWidth;
	private float nextMove;
	public Camera camera;
	public GameObject explosion;
	float time,roadMin,roadMax;
	void Start () {
		laneWidth = CameraWidth() / lanes;
		roadMin = -(CameraWidth () - laneWidth) / 2;
		roadMax = -roadMin;
		transform.position=new Vector3(roadMin + laneWidth,transform.position.y,transform.position.z);
	}

	float CameraWidth()
	{
		float height = 2f * camera.orthographicSize;
		return height * camera.aspect;
	}

	float CameraHeight()
	{
		return 2f * camera.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal=Input.GetAxisRaw("Horizontal");
		//time+=Time.deltaTime;
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Began) {
				//Debug.Log ("Right "+ laneWidth);
				if (touch.position.x>Screen.width/2) {
					float x = Mathf.Clamp (transform.position.x + laneWidth, roadMin, roadMax);

					transform.position = new Vector3 (x, transform.position.y, transform.position.z);
				} else {
					float x = Mathf.Clamp (transform.position.x - laneWidth, roadMin, roadMax);

					transform.position = new Vector3 (x, transform.position.y, transform.position.z);
				}
				
			} 
		}

		if (horizontal == 1f && Time.time > nextMove) {
			nextMove = Time.time + moveRate;
			float x = Mathf.Clamp (transform.position.x + laneWidth, roadMin, roadMax);
			transform.position=new Vector3(x,transform.position.y,transform.position.z);
		} 
		else if (horizontal == -1f && Time.time > nextMove) {
			nextMove = Time.time + moveRate;
			float x = Mathf.Clamp (transform.position.x - laneWidth, roadMin, roadMax);
			transform.position=new Vector3(x,transform.position.y,transform.position.z);
		}
	}

	void OnTriggerEnter(Collider other){
		Debug.Log (other.gameObject.name);
		if (other.gameObject.tag == "Boundary") {
			return;
		}
		Instantiate (explosion);
		GameController gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		PlayerPrefs.SetInt("Score",gameController.getScore());
		if (PlayerPrefs.HasKey ("High_Score")) {
			if (gameController.getScore () > PlayerPrefs.GetInt ("High_Score"))
				PlayerPrefs.SetInt ("High_Score", gameController.getScore());
		} else {
			PlayerPrefs.SetInt ("High_Score", gameController.getScore());
		}
		PlayerPrefs.SetInt ("Show_Score", 1);

		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
}
