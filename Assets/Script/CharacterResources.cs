using UnityEngine;
using System.Collections;

public class CharacterResources : MonoBehaviour {
	
	public int pv=10;
	public GameObject hitFeedBack;
	void Hit(int damage){
		Instantiate(hitFeedBack, transform.position,Quaternion.identity);
		pv-=damage;
		if(pv<=0){
			Destroy(gameObject);
		}
			
	}

    void LifeUp()
    {
        pv++;
    }
    void LifeDown()
    {
        pv--;
    }
}
