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

		
		AnimatorStateInfo currentBaseState=anim.GetCurrentAnimatorStateInfo(1);
				
		if(currentBaseState.nameHash != Animator.StringToHash("Hit.hit")){
			
			weapon.isHitting=false;
			if(Input.GetButtonDown("Fire1")){
				anim.SetBool("hit", true);
				weapon.StartHit();
			}else{
				anim.SetBool("hit", false);
			}
			
		}else{
			weapon.isHitting=true;
		}
				
	}
}