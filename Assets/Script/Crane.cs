using UnityEngine;
using System.Collections;

public class Crane : MonoBehaviour {

	GameObject target;
	public float speed=1;
	public GameObject skin;
	public enum IAType{simple, circle}
	// Use this for initialization
	void Start () {
		target=GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 distance=target.transform.position-transform.position;
		distance.Normalize();
		transform.Translate(distance.normalized*speed*Time.deltaTime);
		CharacterLookAt(distance);
	}
	
	void Simple(){
		
	}
	
	void CharacterLookAt(Vector3 pos){
		pos+=skin.transform.position;
		skin.transform.LookAt(pos);
	}
}
