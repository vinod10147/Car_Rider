using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	// Use this for initialization
	public int lanes;
	public Camera camera;
	public GameObject road;
	public Transform roadSpawn;
	public GameObject opponent;
	public Text Score;
	private float laneWidth;
	float time,roadMin,roadMax;
	Rigidbody rb;
	int[] lanevalues=new int[]{-3,-1,1,3};
	private float opponentRate=0.6f;
	private int score;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		laneWidth = CameraWidth() / lanes;
		roadMin = -(CameraWidth () - laneWidth) / 2;
		roadMax = -roadMin;
		time = Time.time;
		StartCoroutine (SpawnWaves (lanes));
	}
	public void addScore(int sc)
	{
		score += sc;
		Score.text = ""+score;
	}

	public int getScore(){
		return score;
	}

	IEnumerator SpawnWaves (int lanes)
	{
		while (true)
		{
			
				Vector3 spawnPosition = new Vector3 (lanevalues[Random.Range(0,lanevalues.Length)]*laneWidth/2, 0f, roadSpawn.position.z);
				Quaternion spawnRotation = Quaternion.identity;
				GameObject op=Instantiate (opponent, spawnPosition, spawnRotation);
			mover mv = op.GetComponent<mover> ();
			float oldspeed = mv.speed;
	
			mv.speed -= (Time.time-time)/10;
			opponentRate = opponentRate - Mathf.Abs(oldspeed/mv.speed)/500;
				yield return new WaitForSeconds (opponentRate);
		}
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




	public void generateRoad(){
		GameObject newRoad = Instantiate (road);
		newRoad.transform.position=new Vector3(roadSpawn.position.x,roadSpawn.position.y+Random.Range(0f,1),roadSpawn.position.z);
		mover mv = newRoad.GetComponent<mover> ();
		mv.speed -= (Time.time-time)/10;

		//Debug.Log (Time.time - time);
	}

	void Update () {
		
	}
}
