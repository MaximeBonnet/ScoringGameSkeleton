using UnityEngine;
using System.Collections;

public class CharacterResources : MonoBehaviour {
	
	public int pv=10;
	public GameObject hitFeedBack;
	public int score;
	void Hit(int damage){
		Instantiate(hitFeedBack, transform.position,Quaternion.identity);
		pv-=damage;
		if(pv<=0){
			
			PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+score);
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
