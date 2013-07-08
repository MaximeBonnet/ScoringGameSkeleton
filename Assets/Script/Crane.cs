using UnityEngine;
using System.Collections;

public class Crane : MonoBehaviour {

	GameObject target;
	// Use this for initialization
	void Start () {
		target=GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
