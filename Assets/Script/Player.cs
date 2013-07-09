using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


    public GameObject[] partPlayer;
	MoveCharacter moveCharacter;
	public WeaponCollider weapon;
	public MeleeWeaponTrail trail;
	public Animator anim;
	// Use this for initialization
	void Start () {
		moveCharacter=GetComponent<MoveCharacter>();
		anim.SetLayerWeight(1,1);
		PlayerPrefs.SetInt("score",0);
        ChangeTexture();
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
			trail.Emit=false;
		}else{
			weapon.isHitting=true;
			trail.Emit=true;
		}
				
	}
	void OnDestroy(){
		Application.LoadLevel("GameOver");
	}

    void ChangeTexture()
    {
        if (AssetBundleRetriever.texture != null)
        {
            foreach (GameObject part in partPlayer)
            {
                part.renderer.material.SetTexture("_MainTex", AssetBundleRetriever.texture);
            }
        }
    }
	
	void OnGUI(){
		GUI.Label(new Rect(10f,2*Screen.height/15,200,50), PlayerPrefs.GetInt("score").ToString());
	}
}