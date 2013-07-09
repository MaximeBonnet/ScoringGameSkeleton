using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RessourcesPlayer : CharacterResources {
	
	public Stack<GameObject> pvVisuels;
	
	public GameObject pvVisuel;
	
	public Vector3 offset;
	public Vector3 distBetweenPv=Vector3.one;
	// Use this for initialization
	void Start () {
		pvVisuels=new Stack<GameObject>();
		Camera cam = Camera.main;
		Vector3 posLeftTop=cam.ScreenToWorldPoint(new Vector3(0,Screen.height,10));
		for(int i=0; i<pv ; i+=10){
			GameObject obj= Instantiate(pvVisuel, posLeftTop+offset+i*distBetweenPv, Quaternion.identity) as GameObject;
			pvVisuels.Push(obj);
			obj.transform.parent=cam.transform;
		}
	}
	void Hit(int damage){
		Instantiate(hitFeedBack, transform.position,Quaternion.identity);
		pv-=damage;
		for(int i=0; i<damage ; i+=10){
			Destroy(pvVisuels.Pop());
		}
		if(pv<=0){
			
			PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+score);
			Destroy(gameObject);
		}
			
	}
}
