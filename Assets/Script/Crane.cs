using UnityEngine;
using System.Collections;

public class Crane : MonoBehaviour {

	GameObject target;
	public float speed=1;
	public GameObject skin;
	public enum IAType{simple, circle};
	public IAType IA;
	
	public ParticleEmitter[] particles;
	
	int circleDir=1;
	// Use this for initialization
	void Start () {
		target=GameObject.Find("Player");
		if(IA==IAType.circle){
			if(Random.Range(0,2)==0){
				circleDir=-1;	
			}
		}
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
		transform.Translate(distance*speed*0.5f*Time.deltaTime);
		CharacterLookAt(distance);
		if(circleDir>0)
			distance=new Vector3(distance.y, -distance.x, 0);
		else
			distance=new Vector3(-distance.y, distance.x, 0);
		transform.Translate(distance*speed*2*Time.deltaTime);
		
	}
	
	void Simple(){
		Vector3 distance=target.transform.position-transform.position;
		distance.Normalize();
		transform.Translate(distance*speed*Time.deltaTime);
		CharacterLookAt(distance);
	}
	
	void CharacterLookAt(Vector3 pos){
		pos+=skin.transform.position;
		skin.transform.LookAt(pos);
	}
	void OnDestroy(){
//		ParticleEmitter[] particles= GetComponentsInChildren<ParticleEmitter>();	
		foreach(ParticleEmitter particle in particles){
			particle.emit=false;
			particle.transform.parent=null;
		}
	}
}
