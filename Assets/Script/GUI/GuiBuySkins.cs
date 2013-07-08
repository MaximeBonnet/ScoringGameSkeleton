using UnityEngine;
using System.Collections;

public class GuiBuySkins : MonoBehaviour {

    public GameObject[] objectsToChange;
    bool textureChanged = false;
    bool changeTexture = false;
	// Use this for initialization
	void Start () {
        
        BundleDatas.jaune = PlayerPrefs.GetInt("jaune") == 1;
        BundleDatas.bleu = PlayerPrefs.GetInt("bleu") == 1;
        BundleDatas.turquoise = PlayerPrefs.GetInt("turquoise") == 1;
        BundleDatas.vert = PlayerPrefs.GetInt("vert") == 1;
        BundleDatas.violet = PlayerPrefs.GetInt("violet") == 1;
        PlayerPrefs.SetString("color", "rouge");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (AssetBundleRetriever.texture != null && !textureChanged){
            ChangeTexture();
        }

    }


    void OnGUI()
    {
        //Reset achat
        if (GUI.Button(new Rect(8 * Screen.width / 10, 1 * Screen.height / 10, 2*Screen.width / 10f, Screen.height / 15f), "Réinitialiser achats"))
        {
            PlayerPrefs.DeleteAll();
            ReadAchats();
        }
        //Selection Texture

        if (BundleDatas.jaune && GUI.Button(new Rect(8 * Screen.width / 10, 2 * Screen.height / 10, Screen.width/10f, Screen.height/15f), "Jaune"))
        {
            changeTexture = true;
            textureChanged = false;
            AssetBundleRetriever.texture = null;
            StartCoroutine(AssetBundleRetriever.RetrieveTexture("http://romainpedra.fr/games/ExamUnity/YellowTexture.unity3d", "skeleton_warrior__variant3"));
            PlayerPrefs.SetString("color", "jaune");
        }

        if (BundleDatas.bleu && GUI.Button(new Rect(8 * Screen.width / 10, 3 * Screen.height / 10, Screen.width / 10f, Screen.height / 15f), "Bleu"))
        {
            changeTexture = true;
            textureChanged = false;
            AssetBundleRetriever.texture = null;
            StartCoroutine(AssetBundleRetriever.RetrieveTexture("http://romainpedra.fr/games/ExamUnity/BlueTexture.unity3d", "skeleton_warrior__variant4"));
            PlayerPrefs.SetString("color", "bleu");
        }

        if (BundleDatas.turquoise && GUI.Button(new Rect(8 * Screen.width / 10, 4 * Screen.height / 10, Screen.width / 10f, Screen.height / 15f), "Turquoise"))
        {
            changeTexture = true;
            textureChanged = false;
            AssetBundleRetriever.texture = null;
            StartCoroutine(AssetBundleRetriever.RetrieveTexture("http://romainpedra.fr/games/ExamUnity/TurquoiseTexture.unity3d", "skeleton_warrior_variant1"));
            PlayerPrefs.SetString("color", "turquoise");
        }
        if (BundleDatas.vert && GUI.Button(new Rect(8 * Screen.width / 10, 5 * Screen.height / 10, Screen.width / 10f, Screen.height / 15f), "Vert"))
        {
            changeTexture = true;
            textureChanged = false;
            AssetBundleRetriever.texture = null;
            StartCoroutine(AssetBundleRetriever.RetrieveTexture("http://romainpedra.fr/games/ExamUnity/GreenTexture.unity3d", "skeleton_warrior__variant5"));
            PlayerPrefs.SetString("color", "vert");
        }
        if (BundleDatas.violet && GUI.Button(new Rect(8 * Screen.width / 10, 6 * Screen.height / 10, Screen.width / 10f, Screen.height / 15f), "Violet"))
        {
            changeTexture = true;
            textureChanged = false;
            AssetBundleRetriever.texture = null;
            StartCoroutine(AssetBundleRetriever.RetrieveTexture("http://romainpedra.fr/games/ExamUnity/PurpleTexture.unity3d", "skeleton_warrior__variant2"));
            PlayerPrefs.SetString("color", "violet");
        }
        if (GUI.Button(new Rect(8 * Screen.width / 10, 7 * Screen.height / 10, Screen.width / 10f, Screen.height / 15f), "Rouge"))
        {
            changeTexture = true;
            textureChanged = false;
            AssetBundleRetriever.texture = null;
            StartCoroutine(AssetBundleRetriever.RetrieveTexture("http://romainpedra.fr/games/ExamUnity/RedTexture.unity3d", "skeleton_warrior_col_01"));
            PlayerPrefs.SetString("color", "rouge");
        }

        //Buy Buttons
        if (!BundleDatas.jaune && GUI.Button(new Rect(9 * Screen.width / 10, 2 * Screen.height / 10, Screen.width / 10f, Screen.height / 15f), "Déverouiller Jaune"))
        {
            PlayerPrefs.SetInt("jaune", 1);
            BundleDatas.jaune = PlayerPrefs.GetInt("jaune") == 1;

        }

        if (!BundleDatas.bleu && GUI.Button(new Rect(9 * Screen.width / 10, 3 * Screen.height / 10, Screen.width / 10f, Screen.height / 15f), "Déverouiller Bleu"))
        {
            PlayerPrefs.SetInt("bleu", 1);
            BundleDatas.bleu = PlayerPrefs.GetInt("bleu") == 1;
        }

        if (!BundleDatas.turquoise && GUI.Button(new Rect(9 * Screen.width / 10, 4 * Screen.height / 10, Screen.width / 10f, Screen.height / 15f), "Déverouiller Turquoise"))
        {
            PlayerPrefs.SetInt("turquoise", 1);
            BundleDatas.turquoise = PlayerPrefs.GetInt("turquoise") == 1;
        }
        if (!BundleDatas.vert && GUI.Button(new Rect(9 * Screen.width / 10, 5 * Screen.height / 10, Screen.width / 10f, Screen.height / 15f), "Déverouiller Vert"))
        {
            PlayerPrefs.SetInt("vert", 1);
            BundleDatas.vert = PlayerPrefs.GetInt("vert") == 1;
        }
        if (!BundleDatas.violet && GUI.Button(new Rect(9 * Screen.width / 10, 6 * Screen.height / 10, Screen.width / 10f, Screen.height / 15f), "Déverouiller Violet"))
        {
            PlayerPrefs.SetInt("violet", 1);
            BundleDatas.violet = PlayerPrefs.GetInt("violet") == 1;
        }
    }


    void ReadAchats()
    {
        BundleDatas.jaune = PlayerPrefs.GetInt("jaune") == 1;
        BundleDatas.bleu = PlayerPrefs.GetInt("bleu") == 1;
        BundleDatas.turquoise = PlayerPrefs.GetInt("turquoise") == 1;
        BundleDatas.vert = PlayerPrefs.GetInt("vert") == 1;
        BundleDatas.violet = PlayerPrefs.GetInt("violet") == 1;
    }

    void ChangeTexture()
    {
        foreach (GameObject part in objectsToChange)
        {
            part.renderer.material.SetTexture("_MainTex", AssetBundleRetriever.texture);
        }
        textureChanged = true;
    }
}
