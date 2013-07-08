using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Mode  {
	
	public int position;
	
	public List<List<int>> logic;
	
	public Mode(int position, List<List<int>> logic)
    {
        this.position = position;
        this.logic = logic;
		
    }

}
