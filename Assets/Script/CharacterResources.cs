using UnityEngine;
using System.Collections;

public class CharacterResources : MonoBehaviour {
	
	public int pv=10;
	
	void Hit(int damage){
		pv-=damage;
		if(pv<=0){
			Destroy(gameObject);
		}
			
	}
}
