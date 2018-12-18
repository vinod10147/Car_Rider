using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	// Use this for initialization
	public Text Score;
	public Text High_Score;
	public GameObject explosion;
	void Start(){
		
		if(PlayerPrefs.HasKey("High_Score"))
			High_Score.text= "Best Score: "+PlayerPrefs.GetInt("High_Score");
		else
			High_Score.text= "Best Score: 0";


		if (PlayerPrefs.HasKey ("Show_Score") && PlayerPrefs.GetInt ("Show_Score") == 1) {
			if (PlayerPrefs.HasKey ("Score")) {
				int score = PlayerPrefs.GetInt ("Score");
				Score.text = "Your Score: " + score.ToString ();  
				Instantiate (explosion);
			}
		}
		if (PlayerPrefs.HasKey ("Show_Score")) {
		//	Instantiate (explosion);
			PlayerPrefs.SetInt ("Show_Score",0);
		}
	}
	public void PlayGame(){

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
	public void Quit(){
		Application.Quit ();
	
	}
}
