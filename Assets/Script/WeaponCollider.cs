using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponCollider : MonoBehaviour {
	
	//si le portuer de l'arme meurt et que l'arme tombe par terre, to do ; isHitting=false (risque d'arme vengeresses =3)
	public bool isHitting=false;
	
	public int damage=10;
	
	public List<Collider> collidedCharacters=new List<Collider>();
	
		
	void OnTriggerEnter(Collider other){
		
		collidedCharacters.Add(other);
		if(isHitting)
		{
			Damage(other);
		}
		
	}
	
	void OnTriggerExit(Collider other){
		collidedCharacters.Remove(other);
	}
	
	public void StartHit(){
		isHitting=true;

		for(int i=0;i<collidedCharacters.Count;i++){
			Collider other=collidedCharacters[i];
			if(other!=null){
				Damage(other);	
			}else{
				collidedCharacters.Remove(other);
				i--;
			}
		}
		
	}
	
	public void Damage(Collider other){
			/*si plusieur layers sont damageables il faudra faire une class/liste/function pour tester si damageable
			ex:	public string[] layersDamageables={"Character"}; >IsDamageable(string jmj){....}...
				*/
		if(other.gameObject.layer!=gameObject.layer){
//			Debug.Log("Hit "+other.name);	
				other.gameObject.SendMessage("Hit", damage,SendMessageOptions.DontRequireReceiver);
		}
	}
	
}
