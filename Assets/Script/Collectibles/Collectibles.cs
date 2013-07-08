using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Collectibles : MonoBehaviour {

    public Player player;
    BoxCollider myCollider;


    public enum TypeResources { LifeUp, BoostSpeed, BoostDegats, LifeDown };

    public TypeResources typeResource;



	// Use this for initialization
	void Start () {
        myCollider = this.GetComponent<BoxCollider>();
        myCollider.isTrigger = true;
        myCollider.size = new Vector3(myCollider.size.x, myCollider.size.y, 100f);
        this.rigidbody.useGravity = false;
        this.rigidbody.isKinematic = true;

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            switch (typeResource)
            {
                case (TypeResources.LifeUp):
                    player.SendMessage("LifeUp", SendMessageOptions.DontRequireReceiver);
                    break;
                case (TypeResources.BoostSpeed):
                    player.SendMessage("BoostSpeed", SendMessageOptions.DontRequireReceiver);
                    break;
                case(TypeResources.BoostDegats):
                    player.SendMessage("BoostDegats", SendMessageOptions.DontRequireReceiver);
                    break;
                case(TypeResources.LifeDown):
                    player.SendMessage("LifeDown", SendMessageOptions.DontRequireReceiver);
                    break;
            }

            Destroy(this.gameObject);
        }
    }


}
