using UnityEngine;
using System.Collections;

public class GuiName : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnGUI () {
		GUI.TextField(new Rect(Screen.width/2-250,Screen.height/2, 250, 25), "bouya");
	}
}
