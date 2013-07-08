using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ScoreHandler {


    public static Dictionary<string, int> scores;

    public static IEnumerator SubmitScore(string url, string pseudo, int score)
    {

        string finalUrl = url + "?pseudo=" + WWW.EscapeURL(pseudo) + "&score=" + WWW.EscapeURL(score.ToString());

        WWW www = new WWW(finalUrl);
        Debug.Log("Submitting");
        yield return www;

        if (www.error != null && www.error != "")
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Success");
        }

    }


    public static IEnumerator GetScores(){

        WWW www = new WWW("http://romainpedra.fr/games/ExamUnity/listerScores.php");

        yield return www;

        Debug.Log(www.text);
        
        Process(www.text);
        
    }


    public static void Process(string datas)
    {
        scores = new Dictionary<string, int>();
        string[] splittedDatas = datas.Split(';');
        for (int i = 0; i <= splittedDatas.Length - 2; i += 2)
        {
            scores.Add(splittedDatas[i], int.Parse(splittedDatas[i + 1]));
        }

    }

}
