using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	MoveCharacter moveCharacter;
	public WeaponCollider weapon;
	public Animator anim;
	// Use this for initialization
	void Start () {
		moveCharacter=GetComponent<MoveCharacter>();
		anim.SetLayerWeight(1,1);
	}
	
	// Update is called once per frame
	void Update () {		
		moveCharacter.UpdateMoveManager(Input.GetAxis("Horizontal"),Input.GetButtonDown("Jump"));
		if(Input.GetButtonDown("Fire1")){
			anim.SetBool("hit", true);
			
		}else{
			anim.SetBool("hit", false);
		}
	}
}
