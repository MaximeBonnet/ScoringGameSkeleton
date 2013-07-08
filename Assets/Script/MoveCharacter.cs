using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

	public float moveSpeed = 10.0F;
	public float jumpSpeed = 40.0F;
	public float dodgeSpeed = 40.0F;
	public float cooldoownDodge=0.5f;
	
	public float blockSpeedModif=0.5f;
	
	public float gravity = 1.0F;
	
	public float forceResistance=0.9f;
	public float forceMin=5f;
	
	public GameObject groundDetecionTrigger;
	public GameObject skin;
	
	public Vector3 moveDirection = Vector3.zero;
	public Vector3 force;
	public Vector3 jumpForce = Vector3.zero;
	
	GroundDetection groundDetecion;
	
	
	Animator anim;
	private AnimatorStateInfo currentBaseState;	
	
//	static int runningState = Animator.StringToHash("Base Layer.Run");
	
	bool canDodge=true;
	
//	public PlayerState playerState = PlayerState.nothing;

	
	void Start(){
		anim = skin.GetComponent<Animator>();
		groundDetecion=groundDetecionTrigger.GetComponent<GroundDetection>();
	}
	
	
	//UpdateMove?
	public void UpdateMoveManager(float x, bool jump) {
		
		moveDirection = new Vector3(x, 0, 0).normalized;
		anim.SetFloat("move", x);
	
		if (groundDetecion.IsGrouded()){
			anim.SetBool("jump", false);
			if(jump){
				Jump();
			}else{
				
				if(jumpForce.y<=0){
					jumpForce=Vector3.zero;
				}
	//			anim.SetBool("isFalling", false);
			}
		}else{
			//if(falling!=Vector3.zero)//pour éviter le bug trigger
			//	anim.SetBool("isFalling", true);
			if(jumpForce.y>-100)
				jumpForce-=new Vector3(0, gravity, 0);
		}
		
		rigidbody.velocity=moveDirection*moveSpeed+force+jumpForce;
		
		force.y-=forceResistance*Time.deltaTime;	
		if(force.magnitude<forceMin)
			force=Vector3.zero;
		
		AnimatorStateInfo currentBaseState=anim.GetCurrentAnimatorStateInfo(1);
				
		if(currentBaseState.nameHash != Animator.StringToHash("Hit.hit")){
			CharacterLookAt(moveDirection);
		}
//		anim.SetFloat(MekanimVar.moveFront, moveDirection.z);
	}
	
	public void Jump(){
		if(groundDetecion.IsGrouded()){
			anim.SetBool("jump", true);
			jumpForce = Vector3.up*jumpSpeed;
		}else{
//			anim.SetBool("jump", false);
		}
	}

	public void Dash(Vector3 direction, float dashSpeed, float fallSpeed){
//		Vector3 direction=new Vector3(mousepos.x-Screen.width/2 ,0, mousepos.y-Screen.height/2);
		force = direction.normalized*dashSpeed;
		force+=-Vector3.up*fallSpeed;
//		CharacterLookAtMouse(mousepos);
	}
	
	void CharacterLookAt(Vector3 pos){
		pos+=skin.transform.position;
		skin.transform.LookAt(pos);
	}
}
