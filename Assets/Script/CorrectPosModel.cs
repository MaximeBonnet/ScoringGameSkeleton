using UnityEngine;
using System.Collections;

public class CorrectPosModel : MonoBehaviour {
	
//	Transform transform;
	Vector3 position;
	// Use this for initialization
	void Start () {
//		transform=gameObject.transform;
		position=gameObject.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.localPosition=position;
	}
}
