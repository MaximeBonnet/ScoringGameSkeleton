using UnityEngine;
using System.Collections;

public class GuiName : MonoBehaviour {
	public string name="Bouya";
	// Use this for initialization
	void Start () {




		name=PlayerPrefs.GetString("name");
		if(name==""){
			name="Enter a name";	
		}
	}
	
	void Update(){
		if(Input.GetButtonDown("Jump")&&name!=""){
			PlayerPrefs.SetString("name", name);
			Application.LoadLevel("Game");
		}
	}
	
	void OnGUI () {
		name=GUI.TextField(new Rect(Screen.width/2-250,Screen.height-25, 250, 25), name);
		if(GUI.Button(new Rect(Screen.width/2,Screen.height-25, 50, 25), "ok")&&name!=""){
			PlayerPrefs.SetString("name", name);
			Application.LoadLevel("Game");
		}
		
//		if(GUI.Button(new Rect(Screen.width/2,0, 50, 25), "ok")&&name!=""){
//			PlayerPrefs.SetString("name", name);
//			Application.LoadLevel("Game");
//		}
	}
}
