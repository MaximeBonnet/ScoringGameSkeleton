using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(ScoreHandler.SubmitScore("http://romainpedra.fr/games/ExamUnity/saveScore.php",PlayerPrefs.GetString("name"),PlayerPrefs.GetInt("score")));

	}
	
	// Update is called once per frame
	void Update () {
		if(ScoreHandler.submited){
			ScoreHandler.submited=false;
			Application.LoadLevel("MenuStart");
		}
	}
}
