using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NotePlayer : MonoBehaviour {
	
	public bool isPlaying=false;
	
	public float tempoSec=1;
	
	private float timeNextPlay;
	
	#region Modes
	
	private Mode maxMode = new Mode(1, new List<List<int>>
	{
	new List<int> {1,2,5,6},
	new List<int> {0,2,3,6},
	new List<int> {0,1,3,4},
	new List<int> {1,2,4,5},
	new List<int> {2,3,5,6},
	new List<int> {0,3,4,6},
	new List<int> {0,1,4,5}
	});
	
	private Mode IONIAN = new Mode(1, new List<List<int>>
	{
		new List<int> {2, 3, 4, 5, 6},
		new List<int> {1, 3, 5},
		new List<int> {4, 5, 8},
		new List<int> {3, 5},
		new List<int> {1, 2, 3, 4, 6},
		new List<int> {5},
		new List<int> {5, 6}
	});
	
	private Mode DORIAN = new Mode(2, new List<List<int>>
	{
		new List<int> {3, 5, 7, 8},
		new List<int> {5, 6, 7},
		new List<int> {1, 4, 5, 6, 7, 8},
		new List<int> {5, 6, 7, 8},
		new List<int> {3, 6, 7, 8},
		new List<int> {1, 4, 5, 7, 8},
		new List<int> {3, 5, 6, 8},
		new List<int> {1, 3, 4, 5, 7},
		new List<int> {1, 5, 8}
	});
	
	#endregion
	
	#region Notes
	
	public Note note1 = new Note("1");//C3
	public Note note2 = new Note("2");//D3
	public Note note3 = new Note("3");//E3
	public Note note4 = new Note("4");//F3
	public Note note5 = new Note("5");//G3
	public Note note6 = new Note("6");//A3
	public Note note7 = new Note("7");//B3
	
	#endregion Notes
	
	private List<Note> C_MAJOR;
	private Note lastNotePlayed;
	private Note nextToLastNotePlayed;
	private Mode currentMode;
	
	void Start()
	{
		renderer.material.color=Color.blue;
	C_MAJOR = new List<Note> { note1, note2, note3, note4, note5, note6, note7};
	currentMode = maxMode;
	}
	
	void Update(){
		if(!isPlaying)
			return;
		if(Input.GetButtonDown("Jump"))
			PlayNote();
			
		if(Time.time>timeNextPlay){
			PlayNote();
			GetNextRythme();
		}
	
	}
	
	IEnumerator Croche() {
		
		yield return new WaitForSeconds(tempoSec/2);
		PlayNote();
		
//		int rythme = Random.Range(0,2);
//		if(rythme==0){
//			yield return new WaitForSeconds(tempoSec/4);
//			PlayNote();
//		}
	}
	IEnumerator DoubleCroche() {
		
		yield return new WaitForSeconds(tempoSec/4);
		PlayNote();
		yield return new WaitForSeconds(tempoSec/4);
		PlayNote();
		int rythme = Random.Range(0,2);
		if(rythme==0){
			yield return new WaitForSeconds(tempoSec/4);
			PlayNote();
		}
	}
	
	void GetNextRythme(){
		int rythme = Random.Range(0,3/*4*/);
		Debug.Log("nextplay="+rythme);
		switch (rythme){
			case 0: //blanche
				timeNextPlay=Time.time+tempoSec*2;
				break;
			case 1: //noire
					timeNextPlay=Time.time+tempoSec;
					break;
			case 2: //croche
					timeNextPlay=Time.time+tempoSec;
					StartCoroutine("Croche");
					break;
//				case 3: //doublecroche
//						timeNextPlay=Time.time+tempoSec;
//						StartCoroutine("DoubleCroche");
//						break;
		
		}
	}
	
	public void PlayNote()
	{
		Note noteToPlay = GetNote(currentMode);
		
		
		Debug.Log(noteToPlay.name);
		
		nextToLastNotePlayed = lastNotePlayed;
		lastNotePlayed = noteToPlay;
		noteToPlay.sound.Play();
//		AudioSource.PlayClipAtPoint( noteToPlay.sound, transform.position);
	}
	
	
	private Note GetNote(Mode modeToUse)
	{
		List<int> noteChoices = new List<int>();
		
		bool found = false;
		
		List<Note> loadout = C_MAJOR;
		//            for (int i = 0; i < 7; i++)
		//            {
		//                loadout.Add(C_MAJOR[i + modeToUse.position - 1]);
		//            }
		
		for (int j = 0; j < C_MAJOR.Count; j++)
		{
			if (lastNotePlayed == loadout[j])
			{
				Debug.Log("noteChoices"+j);
				noteChoices = modeToUse.logic[j];
				found = true;
				
				break;
			}
		}
		
		if (!found)
		{
			Debug.Log("meh");
			noteChoices = modeToUse.logic[6];
		}
		
		
		//the following hacky sequence should elminate trills
		int randomIndex = Random.Range(0, noteChoices.Count -1);
		
		int choiceIndex = noteChoices[randomIndex];// - 1;
		Debug.Log ("choice index "+choiceIndex);
		Note returnNote = loadout[choiceIndex];
		
		if (returnNote == nextToLastNotePlayed)
		{
			noteChoices.RemoveAt(randomIndex);
			randomIndex = Random.Range(0, noteChoices.Count - 1);
			choiceIndex = noteChoices[randomIndex];// - 1;
			returnNote = loadout[choiceIndex];
		}
		return returnNote;

	}
	
	public void OnMyMouseDown(){
		if(isPlaying){
			renderer.material.color=Color.blue;
		}else{
			renderer.material.color=Color.green;
		}
		isPlaying=!isPlaying;
		
	}
	
}
