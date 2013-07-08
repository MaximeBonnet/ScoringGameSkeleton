using UnityEngine;
using System.Collections;

[System.Serializable]
public class Rythme {
	
	//NO! CHANGE LOGIC! NULE! A REFAIRE!
	
	public float blanche=1,
	noire=1,
	crocheCroche=1,
	crocheDoublecrocheX2=1,
	doublecrocheX2Croche=1,
	doublecrocheX4=1;
	
	public float somme;
	
	public Rythme(){
		somme=blanche + noire + crocheCroche 
			+ crocheDoublecrocheX2 + doublecrocheX2Croche + doublecrocheX4;
	}
	
//	public int GetCurrentRythme(){
//		
//	}
}
