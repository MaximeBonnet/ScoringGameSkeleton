using UnityEngine;
using System.Collections;

public class Poper : MonoBehaviour {
	
	
	public GameObject toPop,
					center;
	public float minDistance=5;
	public float timePop=10;
	public float xPopMin,xPopMax,
				yPopMin,yPopMax;
	
	float nextTimePop;
	// Update is called once per frame
	void Update () {
		if(Time.time>nextTimePop){
			Vector3 pos=center.transform.position;
			Vector3 popPosition=new Vector3(Random.Range(xPopMin,xPopMax),Random.Range(yPopMin,yPopMax),0)+pos;
			while(minDistance>Vector3.Distance(pos,popPosition)){
				popPosition=new Vector3(Random.Range(xPopMin,xPopMax),Random.Range(yPopMin,yPopMax),0)+pos;
			}
			nextTimePop	= Time.time+timePop;
			Instantiate(toPop, popPosition, Quaternion.identity);
			
		}
	}
}
