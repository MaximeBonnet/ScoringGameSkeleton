using UnityEngine;
using System.Collections;

public class TextureChanger : MonoBehaviour {

    bool textureChanged = false;


    public GameObject[] objectsToChange;
	// Use this for initialization
	void Start () {
        StartCoroutine(AssetBundleRetriever.RetrieveTexture("http://romainpedra.fr/games/ExamUnity/YellowTexture.unity3d", "skeleton_warrior__variant3"));
        
	}
	
	// Update is called once per frame
	void Update () {
        if (AssetBundleRetriever.texture != null && !textureChanged)
        {
            foreach (GameObject part in objectsToChange)
            {
                part.renderer.material.SetTexture("_MainTex", AssetBundleRetriever.texture);
            }
            textureChanged = true;
        }
	}
}
