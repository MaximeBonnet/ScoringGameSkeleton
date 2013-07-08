using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreSubmitter : MonoBehaviour {

    bool getted = false;

    

    // Use this for initialization
    void Start () {
        Debug.Log("Starting");
        StartCoroutine(ScoreHandler.SubmitScore("http://romainpedra.fr/games/ExamUnity/saveScore.php","test",500));
    }
    
    // Update is called once per frame
    void Update () {

        if (Time.timeSinceLevelLoad > 3f && !getted)
        {
            StartCoroutine(ScoreHandler.GetScores());
            getted = true;
            GetScores();
        }
    }



    void GetScores()
    {
        if (ScoreHandler.scores != null && ScoreHandler.scores.Count > 0)
        {
            foreach (var pair in ScoreHandler.scores)
            {
                Debug.Log("Pseudo: " + pair.Key + " , Score: " + pair.Value);
            }
        }
    }
}
