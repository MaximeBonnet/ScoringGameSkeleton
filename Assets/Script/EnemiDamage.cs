using UnityEngine;
using System.Collections;

public class EnemiDamage : MonoBehaviour {
	
	public int damage=1;
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.layer!=gameObject.layer){
			other.gameObject.SendMessage("Hit", damage,SendMessageOptions.DontRequireReceiver);
		}
	}
}
