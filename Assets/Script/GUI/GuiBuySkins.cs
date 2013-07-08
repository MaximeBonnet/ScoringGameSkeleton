using UnityEngine;
using System.Collections;

public class GuiBuySkins : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BundleDatas.jaune = PlayerPrefs.GetInt("jaune") == 1;
        BundleDatas.bleu = PlayerPrefs.GetInt("bleu") == 1;
        BundleDatas.turquoise = PlayerPrefs.GetInt("turquoise") == 1;
        BundleDatas.vert = PlayerPrefs.GetInt("vert") == 1;
        BundleDatas.violet = PlayerPrefs.GetInt("violet") == 1;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}


    void OnGUI()
    {
        if (GUI.Button(new Rect(8 * Screen.width / 10, 2 * Screen.height / 10, 100f, 50f), "Red"))
        {

        }

        if (GUI.Button(new Rect(8 * Screen.width / 10, 3 * Screen.height / 10, 100f, 50f), "Bleu"))
        {

        }
    }


    
}
