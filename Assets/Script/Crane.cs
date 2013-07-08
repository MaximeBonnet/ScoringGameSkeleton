using UnityEngine;
using System.Collections;

public class Crane : MonoBehaviour {

	GameObject target;
	public float speed=1;
	public GameObject skin;
	public enum IAType{simple, circle};
	public IAType IA;
	// Use this for initialization
	void Start () {
		target=GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		switch (IA){
			case IAType.circle:
				Circle();
				break;
			default:
				Simple();
				break;
		}
	}
	
	void Circle(){
		Vector3 distance=target.transform.position-transform.position;
		distance.Normalize();
		transform.Translate(distance.normalized*speed*Time.deltaTime);
		transform.Translate(skin.transform.up*speed);
		CharacterLookAt(distance);
	}
	
	void Simple(){
		Vector3 distance=target.transform.position-transform.position;
		distance.Normalize();
		transform.Translate(distance.normalized*speed*Time.deltaTime);
		CharacterLookAt(distance);
	}
	
	void CharacterLookAt(Vector3 pos){
		pos+=skin.transform.position;
		skin.transform.LookAt(pos);
	}
}
