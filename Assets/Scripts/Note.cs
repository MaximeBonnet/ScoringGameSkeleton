using UnityEngine;
using System.Collections;

[System.Serializable]
public class Note{
	
	public string name;
	
	public AudioSource sound;
	
	public Note(string name)
    {
        this.name = name;
    }
}

