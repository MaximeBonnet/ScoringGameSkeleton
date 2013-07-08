using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GuiDisplayScores : MonoBehaviour {
	
	
	bool scoreLoaded = false;
	public static Dictionary<string, int> scores;
	// Use this for initialization
	void Start () {
		ScoreHandler.scores=null;
		StartCoroutine (ScoreHandler.GetScores());
		
	}
	void Update(){
		if(ScoreHandler.scores != null && !scoreLoaded){
            Debug.Log("Score REady to display");
			scores=ScoreHandler.scores;
			scoreLoaded = true;
		}
			
	}
	void OnGUI () {
		int i=0;
        if (scores != null)
        {
            //Debug.Log(scores.Count);
            foreach (var pair in scores)
            {
                //Debug.Log(pair.Key+" "+pair.Value);
                GUI.Label(new Rect(2*Screen.width/10, i * 25 + 50, Screen.width, 100), pair.Key + " " + pair.Value);
                i++;
            }
        }

        if (GUI.Button(new Rect(2 * Screen.width / 10f, 8 * Screen.height / 10f, Screen.width / 10f, Screen.height / 10f),"Reload Scores"))
        {
            scoreLoaded = false;
            scores = null;
            ScoreHandler.scores = null;
            StartCoroutine(ScoreHandler.GetScores());
            
        }
	}
}
