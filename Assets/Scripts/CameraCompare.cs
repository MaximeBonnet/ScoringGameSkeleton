using UnityEngine;
using System.Collections;

public class CameraCompare : MonoBehaviour {

	public static int Compare(Camera x, Camera y){
		if(x.depth==y.depth){
			return 0;	
		}
		return (int)(x.depth-y.depth);
	}
}
