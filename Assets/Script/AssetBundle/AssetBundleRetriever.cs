using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AssetBundleRetriever {

    public static Texture texture;

    public static IEnumerator RetrieveTexture(string url,string textureName){
        while (!Caching.ready)
        {
            Debug.Log("NoCache");
            yield return null;
        }
        Debug.Log("Preparing Loading");
        using (WWW www = WWW.LoadFromCacheOrDownload(url,1))
        {
            Debug.Log("Loading");
            yield return www;
            if (www.error != null)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Loaded");
                AssetBundle bundle = www.assetBundle;
                texture = (Texture)bundle.Load(textureName,typeof(Texture));
            }
        }
    }
}
